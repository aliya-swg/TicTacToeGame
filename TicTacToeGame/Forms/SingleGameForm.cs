namespace TicTacToeGame.Forms
{
    public partial class SingleGameForm : Form
    {
        private const byte boardSize = 3;
        private bool _isPlayerX = true;
        private readonly Image[] _images;
        private byte _movesCount = 0;
        private readonly PictureBox[,] _cells = new PictureBox[boardSize, boardSize];

        public SingleGameForm()
        {
            InitializeComponent();

            _images =
            [
                Properties.Resources.cat1,
                Properties.Resources.cat2,
                Properties.Resources.Розовый_кот,
                Properties.Resources.Синий_кот
            ];

            turn_lbl.Text = "Ход крестика!";
            _cells =  new PictureBox[,] { { cell1_pb, cell2_pb, cell3_pb }, { cell4_pb, cell5_pb, cell6_pb }, { cell7_pb, cell8_pb, cell9_pb } };
        }

        public void Cell_Click(object sender, EventArgs e)
        {
            PictureBox clickedCell = (PictureBox)sender;

            if (clickedCell.Image != null) return;

            clickedCell.Image = _images[_isPlayerX ? 0 : 1];
            _movesCount++;

            CheckForWinner();

            _isPlayerX = !_isPlayerX;

            if (_isPlayerX)
            {
                turn_lbl.Text = "Ход крестика!";
            }
            else
            {
                turn_lbl.Text = "Ход нолика!";
            }
        }

        private void CheckForWinner()
        {
            for (int row = 0; row < boardSize; row++)
            {
                if (_cells[row, 0].Image == _cells[row, 1].Image &&
                    _cells[row, 1].Image == _cells[row, 2].Image &&
                    _cells[row, 0].Image != null)
                {
                    MessageBox.Show($"Победил игрок {'X'}");
                    ResetGame();
                    return;
                }
            }

            for (int col = 0; col < boardSize; col++)
            {
                if (_cells[0, col].Image == _cells[1, col].Image &&
                    _cells[1, col].Image == _cells[2, col].Image &&
                    _cells[0, col].Image != null)
                {
                    MessageBox.Show($"Победил игрок {'O'}");
                    ResetGame();
                    return;
                }
            }

            if (_cells[0, 0].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 2].Image &&
                _cells[0, 0].Image != null)
            {
                MessageBox.Show($"Победил игрок {'X'}");
                ResetGame();
                return;
            }

            if (_cells[0, 2].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 0].Image &&
                _cells[0, 2].Image != null)
            {
                MessageBox.Show($"Победил игрок {'O'}");
                ResetGame();
                return;
            }

            if (_movesCount == boardSize * boardSize)
            {
                MessageBox.Show("Ничья!");
                ResetGame();
            }
        }
        private void ResetGame()
        {
            foreach (var cell in _cells)
            {
                if (cell.Image != null)
                {
                    cell.Image = null;
                }
            }

            _isPlayerX = true;
            _movesCount = 0;
        }
    }
}
