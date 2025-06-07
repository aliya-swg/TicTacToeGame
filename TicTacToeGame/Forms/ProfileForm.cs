using TicTacToeGame.Classes;
using TicTacToeGame.Models;

namespace TicTacToeGame.Forms
{
    public partial class ProfileForm : Form
    {
        public event EventHandler ProfileExit;
        public ProfileForm()
        {
            InitializeComponent();
            Logger.LogInfo("Открытие профиля пользователя");

            starCount_lbl.Text = CurrentUser.Instance.NumWins.ToString();
            name_lbl.Text = CurrentUser.Instance.Name;
            ProfileExit += exitAcc_btn_Click;
        }

        private void exitAcc_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userLogin_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Попытка изменения имени пользователя");
            string newName = ShowInputDialog("Изменить имя", "Введите новое имя:");

            if (string.IsNullOrWhiteSpace(newName))
            {
                if (newName == null)
                    return;

                Logger.LogWarning("Попытка установить пустое имя");
                MessageBox.Show("Имя не может быть пустым.");
                return;
            }

            if (newName == CurrentUser.Instance.Name)
            {
                Logger.LogWarning("Новое имя совпадает с текущим");
                MessageBox.Show("Новое имя совпадает с текущим.");
                return;
            }

            using (AppDbContext dbContext = new AppDbContext())
            {
                Logger.LogInfo($"Изменение имени пользователя с {CurrentUser.Instance.Name} на {newName}");
                CurrentUser.Instance.Name = newName;
                dbContext.SaveChanges();
            }
        }
        private string ShowInputDialog(string caption, string label)
        {
            Form inputForm = new Form();
            inputForm.Width = 300;
            inputForm.Height = 150;
            inputForm.Text = caption;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;
            inputForm.AcceptButton = null;

            Label lblLabel = new Label() { Width = 260, Text = label, Location = new Point(10, 10) };
            TextBox txtInput = new TextBox() { Width = 260, Location = new Point(10, 35) };
            Button btnOk = new Button() { Text = "Сохранить", Location = new Point(180, 70), DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Отмена", Location = new Point(90, 70), DialogResult = DialogResult.Cancel };

            inputForm.Controls.Add(lblLabel);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOk);
            inputForm.Controls.Add(btnCancel);
            inputForm.AcceptButton = btnOk;
            inputForm.CancelButton = btnCancel;

            var result = inputForm.ShowDialog();
            return result == DialogResult.OK ? txtInput.Text.Trim() : null;
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowChangePasswordDialog()
        {
            Form dialog = new Form();
            dialog.Text = "Сменить пароль";
            dialog.Width = 300;
            dialog.Height = 250;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;
            dialog.AcceptButton = null;

            Label lblOldPass = new Label() { Text = "Старый пароль:", Location = new Point(20, 20), Width = 120 };
            TextBox txtOldPass = new TextBox() { Location = new Point(20, 45), Width = 230, UseSystemPasswordChar = true };

            Label lblNewPass = new Label() { Text = "Новый пароль:", Location = new Point(20, 75), Width = 120 };
            TextBox txtNewPass = new TextBox() { Location = new Point(20, 100), Width = 230, UseSystemPasswordChar = true };

            Label lblConfirmPass = new Label() { Text = "Подтвердите пароль:", Location = new Point(20, 130), Width = 120 };
            TextBox txtConfirmPass = new TextBox() { Location = new Point(20, 155), Width = 230, UseSystemPasswordChar = true };

            Button btnSave = new Button() { Text = "Сохранить", Location = new Point(20, 190), Width = 100 };
            Button btnCancel = new Button() { Text = "Отмена", Location = new Point(150, 190), Width = 100 };

            DialogResult result = DialogResult.Cancel;

            btnSave.Click += (sender, e) =>
            {
                string oldPass = txtOldPass.Text.Trim();
                string newPass = txtNewPass.Text.Trim();
                string confirmPass = txtConfirmPass.Text.Trim();

                if (string.IsNullOrWhiteSpace(oldPass) ||
                    string.IsNullOrWhiteSpace(newPass) ||
                    string.IsNullOrWhiteSpace(confirmPass))
                {
                    MessageBox.Show("Все поля обязательны.");
                    return;
                }

                if (newPass != confirmPass)
                {
                    MessageBox.Show("Пароли не совпадают.");
                    return;
                }

                string oldHash = HashPassword.Hash(oldPass);
                if (oldHash != CurrentUser.Instance.Password)
                {
                    MessageBox.Show("Старый пароль неверен.");
                    return;
                }

                if (newPass == oldPass)
                {
                    MessageBox.Show("Новый пароль совпадает со старым.");
                    return;
                }

                using (var db = new AppDbContext())
                {
                    var userInDb = db.Users.Find(CurrentUser.Instance.Id);
                    if (userInDb == null)
                    {
                        MessageBox.Show("Пользователь не найден.");
                        return;
                    }

                    userInDb.Password = HashPassword.Hash(newPass);
                    db.SaveChanges();

                    CurrentUser.Instance.Password = userInDb.Password;
                }

                MessageBox.Show("Пароль успешно изменён!");
                result = DialogResult.OK;
                dialog.Close();
            };

            btnCancel.Click += (sender, e) => dialog.Close();

            dialog.Controls.Add(lblOldPass);
            dialog.Controls.Add(txtOldPass);
            dialog.Controls.Add(lblNewPass);
            dialog.Controls.Add(txtNewPass);
            dialog.Controls.Add(lblConfirmPass);
            dialog.Controls.Add(txtConfirmPass);
            dialog.Controls.Add(btnSave);
            dialog.Controls.Add(btnCancel);

            dialog.AcceptButton = btnSave;
            dialog.CancelButton = btnCancel;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Вы можете продолжить работу.");
            }
        }

        private void userPassword_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Открытие диалога смены пароля");
            ShowChangePasswordDialog();
        }
    }
}
