using System.IO;
using TicTacToeGame.Network_classes;

namespace TicTacToeGame.Forms
{
    public partial class NetworkGameForm : Form
    {
        //Game
        private const byte boardSize = 3;
        private bool _isPlay;
        private readonly Image[] _images;
        private byte _movesCount = 0;
        private readonly PictureBox[,] _cells = new PictureBox[boardSize, boardSize];

        //Network
        private GameServer server;
        private GameClient client;
        private Player localPlayer;
        private bool _isHost;

        public NetworkGameForm(bool isHost)
        {
            InitializeComponent();

            _isHost = isHost;
            _isPlay = isHost;
            _images =
            [
                Properties.Resources.cat1,
                Properties.Resources.cat2,
                Properties.Resources.Розовый_кот,
                Properties.Resources.Синий_кот
            ];

            //turn_lbl.Text = "Ход крестика!";
            _cells =  new PictureBox[,]
            {
                { cell00_pb, cell01_pb, cell02_pb },
                { cell10_pb, cell11_pb, cell12_pb },
                { cell20_pb, cell21_pb, cell22_pb }
            };
            InitializeGame(isHost, "192.168.43.207");//ip
        }

        private async void InitializeGame(bool isHostMode, string ip)
        {
            localPlayer = isHostMode ? new Player("X", true) : new Player("O", false);

            if (isHostMode)
            {
                server = new GameServer();
                await server.StartAsync(8888);
                BeginReceivingMoves();
            }
            else
            {
                client = new GameClient();
                await client.ConnectAsync(ip, 8888);
                BeginReceivingMoves();
            }
        }
        private async Task BeginReceivingMoves()
        {
            while (true)
            {
                string message = _isHost
                    ? await server.ReceiveMoveAsync()
                    : await client.ReceiveMoveAsync();

                if (message.StartsWith(GameMessage.PREFIX))
                {
                    string type = GameMessage.ParseMove(message, out int row, out int col);
                    string opponentSymbol = localPlayer.Symbol == "X" ? "O" : "X";

                    Invoke((MethodInvoker)delegate
                    {
                        string pbName = $"cell{row}{col}_pb";
                        var cell = Controls.Find(pbName, true).FirstOrDefault() as PictureBox;
                        if (cell != null && cell.Image == null)
                        {
                            // Отображаем символ противника как изображение
                            cell.Image = opponentSymbol == "X" ? _images[0] : _images[1];
                            _movesCount++;
                            CheckForWinner();

                            _isPlay = !_isPlay;
                            turn_lbl.Text = _isPlay ? "Ход крестика!" : "Ход нолика!";

                        }
                    });
                }
            }
        }

        public async void Cell_Click(object sender, EventArgs e)
        {
            var clickedCell = (PictureBox)sender;

            if (clickedCell.Image != null) return;

            // Проверяем, является ли текущий игрок тем, кто должен ходить
            if (!_isPlay)
            {
                MessageBox.Show("Не ваш ход!");
                return;
            }

            // Отправляем ход
            var row = GetRow(clickedCell.Name);
            var col = GetCol(clickedCell.Name);

            _isPlay = !_isPlay;

            if (_isHost)
                await server.SendMoveAsync(row, col);
            else
                await client.SendMoveAsync(row, col);

            // Ставим изображение
            clickedCell.Image = localPlayer.Symbol == "X" ? _images[0] : _images[1];
            _movesCount++;

            CheckForWinner();
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

                    if (!_isHost)
                        client.Disconnect();
                    else
                        server.Stop();

                    var resultForm = new ResultForm();
                    resultForm.Show();
                    Close();
                }
            }

            for (int col = 0; col < boardSize; col++)
            {
                if (_cells[0, col].Image == _cells[1, col].Image &&
                    _cells[1, col].Image == _cells[2, col].Image &&
                    _cells[0, col].Image != null)
                {
                    MessageBox.Show($"Победил игрок {'O'}");

                    if (!_isHost)
                        client.Disconnect();
                    else
                        server.Stop();

                    var resultForm = new ResultForm();
                    resultForm.Show();
                    Close();
                }
            }

            if (_cells[0, 0].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 2].Image &&
                _cells[0, 0].Image != null)
            {
                MessageBox.Show($"Победил игрок {'X'}");

                if (!_isHost)
                    client.Disconnect();
                else
                    server.Stop();

                Close();
                var resultForm = new ResultForm();
                resultForm.Show();
            }

            if (_cells[0, 2].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 0].Image &&
                _cells[0, 2].Image != null)
            {
                MessageBox.Show($"Победил игрок {'O'}");

                if (!_isHost)
                    client.Disconnect();
                else
                    server.Stop();

                var resultForm = new ResultForm();
                resultForm.Show();
                Close();
            }

            if (_movesCount == boardSize * boardSize)
            {
                MessageBox.Show("Ничья!");

                if (!_isHost)
                    client.Disconnect();
                else
                    server.Stop();

                var resultForm = new ResultForm();
                resultForm.Show();
                Close();
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

            _isPlay = true;
            _movesCount = 0;
        }
        private int GetRow(string cellName)
        {
            return int.Parse(cellName.Substring(cellName.Length - 5, 1));
        }

        private int GetCol(string cellName)
        {
            return int.Parse(cellName.Substring(cellName.Length - 4, 1));
        }
    }
}
