using TicTacToeGame.Models;
using TicTacToeGame.Classes;

namespace TicTacToeGame.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Logger.LogInfo("Открыта форма входа");
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Начата попытка входа в систему");

            string login = login_txtb.Text.Trim();
            string password = password_txtb.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                Logger.LogWarning("Вход не выполнен: Пустой логин или пароль");
                MessageBox.Show("Логин и пароль обязательны для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (login.Length > 254)
            {
                Logger.LogWarning("Вход не выполнен: Слишком длинный логин");
                MessageBox.Show("Логин слишком длинный.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == login || u.Email == login);

                    if (user == null)
                    {
                        Logger.LogWarning($"Вход не выполнен: Пользователь не найден для логина: {login}");
                        MessageBox.Show("Пользователь не найден.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (SessionManager.IsUserActive(user.Id))
                    {
                        Logger.LogWarning($"Попытка повторного входа для активного пользователя: {user.Name}");
                        MessageBox.Show("Этот пользователь уже вошел в систему с другого устройства.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string enteredHash = HashPassword.Hash(password);
                    if (enteredHash != user.Password)
                    {
                        Logger.LogWarning($"Вход не выполнен: Неверный пароль для пользователя: {login}");
                        MessageBox.Show("Неверный пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string ipAddress = NetworkHelper.GetLocalIPAddress();
                    SessionManager.RegisterSession(user, ipAddress);

                    Logger.LogInfo($"Пользователь успешно вошел в систему: {user.Name} (ID: {user.Id})");

                    this.Hide();

                    CurrentUser.Instance = user;

                    PreGameForm preGameForm = new PreGameForm();
                    preGameForm.FormClosed += (s, args) =>
                    {
                        SessionManager.LogoutUser(user.Id);
                        Logger.LogInfo("PreGameForm закрыта, возврат к форме входа");
                        this.Show();
                    };

                    preGameForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка в процессе входа в систему", ex);
                MessageBox.Show("Произошла ошибка при входе в систему.", "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void noAcc_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Переход к форме регистрации");
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormClosed += (s, args) => this.Show();

            this.Hide();
            registrationForm.Show();
        }

        private void eyes_pbx_Click(object sender, EventArgs e)
        {
            if (password_txtb.UseSystemPasswordChar == true)
            {
                password_txtb.UseSystemPasswordChar = false;
            }
            else
            {
                password_txtb.UseSystemPasswordChar = true;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.LogInfo("Закрыта форма входа");
            Application.Exit();
        }
    }
}
