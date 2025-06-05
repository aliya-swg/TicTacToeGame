using TicTacToeGame.Model;

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
            string name = name_txtb.Text.Trim();
            string email = email_txtb.Text.Trim();
            string password = password_txtb.Text.Trim();
            string confirmPassword = secPassword_txtb.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля обязательны для заполнения.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            using (var db = new AppDbContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == email);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким email уже существует.");
                    return;
                }

                string passwordHash = HashPassword(password);

                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = passwordHash
                };

                db.Users.Add(user);
                db.SaveChanges();

                MessageBox.Show("Регистрация успешна!");
                this.Close();
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
