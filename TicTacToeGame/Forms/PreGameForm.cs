using TicTacToeGame.Models;

namespace TicTacToeGame.Forms
{
    public partial class PreGameForm : Form
    {
        public PreGameForm()
        {
            InitializeComponent();

            if (CurrentUser.Instance != null)
            {
                stars_lbl.Text = CurrentUser.Instance.NumWins.ToString();
            }
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            using (var form = new SingleGameForm())
            {
                form.ShowDialog();
            }
        }

        private void acc_btn_Click(object sender, EventArgs e)
        {
            using (var form = new ProfileForm())
            {
                form.ProfileExit += (s, ev) =>
                {
                    Close();
                };

                form.ShowDialog();
            }

        }

        private void playNetwork_btn_Click(object sender, EventArgs e)
        {
            var choiceForm = new ChoiceForm();

            choiceForm.Show();
            Hide();

            choiceForm.FormClosed += (s, args) =>
            {
                Show();
            };
        }
    }
}
