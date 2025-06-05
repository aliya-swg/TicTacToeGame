using TicTacToeGame.Models;

namespace TicTacToeGame.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string login = login_txtb.Text.Trim();
            string password = password_txtb.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль обязательны для заполнения.");
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == login || u.Name == login);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.");
                    return;
                }

                string enteredHash = HashPassword(password);
                if (enteredHash != user.Password)
                {
                    MessageBox.Show("Неверный пароль.");
                    return;
                }

                this.Hide();

                CurrentUser.Instance = user;

                PreGameForm preGameForm = new PreGameForm();
                preGameForm.FormClosed += (s, args) =>
                {
                    this.Show();
                };

                preGameForm.Show();
            }
        }

        private void noAcc_btn_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.FormClosed += (s, args) => this.Show();

            this.Hide();
            registrationForm.Show();
        }

        private string HashPassword(string password)
        {
            return System.Security.Cryptography.SHA256.Create()
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                .Select(x => x.ToString("X2")).Aggregate((s1, s2) => s1 + s2);
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
    }
}