namespace TicTacToeGame.Forms
{
    public partial class ResultForm : Form
    {
        public ResultForm(string result)
        {
            InitializeComponent();
            turn_lbl.Text = result;

            if(result == "Победа!")
            {
                label1.Text = "Вы получили одну звезду!";
            }
            else if(result == "Поражение!")
            {
                label1.Text = "Все победы еще впереди!";
            }
            else if (result == "Ничья")
            {
                label1.Text = "Вы были близко к победе!";
            }
        }
        
        private void back_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
