using TicTacToeGame.Model;
using TicTacToeGame.Classes;

namespace TicTacToeGame.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Начата попытка регистрации");

            string name = name_txtb.Text.Trim();
            string email = email_txtb.Text.Trim();
            string password = password_txtb.Text.Trim();
            string confirmPassword = secPassword_txtb.Text.Trim();

            var nameValidation = ValidationHelper.ValidateUsername(name);
            if (!nameValidation.IsValid)
            {
                Logger.LogWarning($"Регистрация не выполнена: {nameValidation.ErrorMessage}");
                MessageBox.Show(nameValidation.ErrorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var emailValidation = ValidationHelper.ValidateEmail(email);
            if (!emailValidation.IsValid)
            {
                Logger.LogWarning($"Регистрация не выполнена: {emailValidation.ErrorMessage}");
                MessageBox.Show(emailValidation.ErrorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passwordValidation = ValidationHelper.ValidatePassword(password);
            if (!passwordValidation.IsValid)
            {
                Logger.LogWarning($"Регистрация не выполнена: {passwordValidation.ErrorMessage}");
                MessageBox.Show(passwordValidation.ErrorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                Logger.LogWarning("Регистрация не выполнена: Пароли не совпадают");
                MessageBox.Show("Пароли не совпадают.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var existingUserByEmail = db.Users.FirstOrDefault(u => u.Email == email);
                    if (existingUserByEmail != null)
                    {
                        Logger.LogWarning($"Регистрация не выполнена: Пользователь с email {email} уже существует");
                        MessageBox.Show("Пользователь с таким email уже существует.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existingUserByName = db.Users.FirstOrDefault(u => u.Name == name);
                    if (existingUserByName != null)
                    {
                        Logger.LogWarning($"Регистрация не выполнена: Пользователь с именем {name} уже существует");
                        MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string passwordHash = HashPassword(password);

                    var user = new User
                    {
                        Name = name,
                        Email = email,
                        Password = passwordHash,
                        NumWins = 0
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    Logger.LogInfo($"Пользователь успешно зарегистрирован: {name} с email {email}");
                    MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка в процессе регистрации", ex);
                MessageBox.Show("Произошла ошибка при регистрации.", "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            return System.Security.Cryptography.SHA256.Create()
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                .Select(x => x.ToString("X2")).Aggregate((s1, s2) => s1 + s2);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Close();
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

        private void eyes2_pbx_Click(object sender, EventArgs e)
        {
            if (secPassword_txtb.UseSystemPasswordChar == true)
            {
                secPassword_txtb.UseSystemPasswordChar = false;
            }
            else
            {
                secPassword_txtb.UseSystemPasswordChar = true;
            }
        }
    }
}
