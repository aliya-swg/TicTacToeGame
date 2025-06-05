using TicTacToeGame.Forms;

namespace TicTacToeGame
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        public void OpenLoginForm()
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            loginForm.Show();
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            OpenLoginForm();
        }
    }
}
