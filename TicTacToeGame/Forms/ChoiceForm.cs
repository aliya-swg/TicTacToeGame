namespace TicTacToeGame.Forms
{
    public partial class ChoiceForm : Form
    {
        public ChoiceForm()
        {
            InitializeComponent();
        }

        private void host_btn_Click(object sender, EventArgs e)
        {
            var form = new NetworkGameForm(true);

            Hide();
            form.Show();

            form.FormClosed += (s, args) =>
            {
                Show();
            };
        }

        private void client_btn_Click(object sender, EventArgs e)
        {
            var form = new NetworkGameForm(false);

            Hide();
            form.Show();

            form.FormClosed += (s, args) =>
            {
                Show();
            };
        }
    }
}
