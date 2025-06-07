using TicTacToeGame.Classes;
using TicTacToeGame.Models;
using TicTacToeGame.Network_classes;

namespace TicTacToeGame.Forms
{
    public partial class NetworkGameForm : Form
    {
        private const byte boardSize = 3;
        private bool _isPlay;
        private readonly Image[] _images;
        private byte _movesCount = 0;
        private readonly PictureBox[,] _cells = new PictureBox[boardSize, boardSize];

        private GameServer server;
        private GameClient client;
        private Player localPlayer;
        private bool _isHost;
        private string _ipAddress;
        private int _port;
        private bool gameStarted = false;
        private bool gameEnded = false;

        public NetworkGameForm(bool isHost, string ipAddress, int port)
        {
            InitializeComponent();
            Logger.LogInfo($"Сетевая игра запущена как {(isHost ? "Хост" : "Клиент")} на {ipAddress}:{port}");

            _isHost = isHost;
            _ipAddress = ipAddress;
            _port = port;
            _isPlay = isHost; 

            _images = new Image[]
            {
                Properties.Resources.cat1,
                Properties.Resources.cat2,
                Properties.Resources.Розовый_кот,
                Properties.Resources.Синий_кот
            };

            _cells = new PictureBox[,]
            {
                { cell00_pb, cell01_pb, cell02_pb },
                { cell10_pb, cell11_pb, cell12_pb },
                { cell20_pb, cell21_pb, cell22_pb }
            };

            InitializeGame();
        }

        private async void InitializeGame()
        {
            try
            {
                localPlayer = _isHost ? new Player("X", true) : new Player("O", false);

                Logger.LogInfo($"Локальный игрок инициализирован как {localPlayer.Symbol}");

                if (_isHost)
                {
                    if (!NetworkHelper.IsPortAvailable(_port))
                    {
                        Logger.LogError($"Порт {_port} уже используется");
                        MessageBox.Show($"Порт {_port} уже используется!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }

                    server = new GameServer();
                    await server.StartAsync(_port);
                    Logger.LogInfo($"Игровой сервер запущен на порту {_port}");

                    if (this.Controls.Find("status_lbl", true).FirstOrDefault() is Label statusLabel)
                    {
                        statusLabel.Text = "Ожидание подключения...";
                    }

                    gameStarted = false;

                    _ = Task.Run(async () => await WaitForPlayerAsync());
                }
                else
                {
                    client = new GameClient();
                    Logger.LogInfo($"Попытка подключения к {_ipAddress}:{_port}");

                    await client.ConnectAsync(_ipAddress, _port);
                    Logger.LogInfo($"Успешно подключен к игровому серверу {_ipAddress}:{_port}");

                    if (this.Controls.Find("status_lbl", true).FirstOrDefault() is Label statusLabel)
                    {
                        statusLabel.Text = "Подключено! Ожидание хода...";
                    }

                    gameStarted = true;

                    _ = Task.Run(async () => await ReceiveMovesAsync());
                }

                UpdateTurnLabel();
            }
            catch (Exception ex)
            {
                Logger.LogError("Не удалось инициализировать сетевую игру", ex);
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async Task WaitForPlayerAsync()
        {
            try
            {
                Logger.LogInfo("Ожидание подключения второго игрока...");

                Invoke(() =>
                {
                    if (this.Controls.Find("status_lbl", true).FirstOrDefault() is Label statusLabel)
                    {
                        statusLabel.Text = "Игрок подключился! Ваш ход!";
                    }
                    gameStarted = true;
                });

                Logger.LogInfo("Второй игрок подключился, игра началась");

                await ReceiveMovesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при ожидании игрока", ex);
            }
        }

        private async Task ReceiveMovesAsync()
        {
            try
            {
                while (!gameEnded)
                {
                    string message = _isHost
                        ? await server.ReceiveMoveAsync()
                        : await client.ReceiveMoveAsync();

                    if (string.IsNullOrEmpty(message))
                        continue;

                    Logger.LogInfo($"Получено сообщение: {message}");

                    if (message.StartsWith(GameMessage.PREFIX))
                    {
                        string type = GameMessage.ParseMove(message, out int row, out int col);
                        string opponentSymbol = localPlayer.Symbol == "X" ? "O" : "X";

                        Invoke(() =>
                        {
                            var cell = _cells[row, col];
                            if (cell != null && cell.Image == null)
                            {
                                cell.Image = opponentSymbol == "X" ? _images[0] : _images[1];
                                _movesCount++;

                                _isPlay = true;
                                UpdateTurnLabel();

                                CheckForWinner();
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при получении ходов", ex);
                if (!gameEnded)
                {
                    Invoke(() =>
                    {
                        MessageBox.Show("Соединение потеряно!", "Ошибка сети",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }

        public async void Cell_Click(object sender, EventArgs e)
        {
            var clickedCell = (PictureBox)sender;

            if (clickedCell.Image != null) return;

            if (!_isPlay || !gameStarted)
            {
                Logger.LogWarning("Игрок попытался сделать ход не в свою очередь");
                MessageBox.Show("Не ваш ход!");
                return;
            }

            var row = GetRow(clickedCell.Name);
            var col = GetCol(clickedCell.Name);

            Logger.LogInfo($"Сетевая игра: Локальный игрок {localPlayer.Symbol} сделал ход [{row},{col}]");

            clickedCell.Image = localPlayer.Symbol == "X" ? _images[0] : _images[1];
            _movesCount++;

            try
            {
                if (_isHost)
                    await server.SendMoveAsync(row, col);
                else
                    await client.SendMoveAsync(row, col);

                Logger.LogInfo("Ход успешно отправлен сопернику");
            }
            catch (Exception ex)
            {
                Logger.LogError("Не удалось отправить ход сопернику", ex);
                MessageBox.Show("Ошибка отправки хода!");
                return;
            }

            _isPlay = false;
            UpdateTurnLabel();

            CheckForWinner();
        }

        private void UpdateTurnLabel()
        {
            try
            {
                if (this.Controls.Find("status_lbl", true).FirstOrDefault() is Label statusLabel)
                {
                    if (_isPlay && gameStarted)
                    {
                        statusLabel.Text = $"Ваш ход ({localPlayer.Symbol})";
                    }
                    else if (gameStarted)
                    {
                        string opponentSymbol = localPlayer.Symbol == "X" ? "O" : "X";
                        statusLabel.Text = $"Ход соперника ({opponentSymbol})";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при обновлении статуса", ex);
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
                    string winner = _cells[row, 0].Image == _images[0] ? "X" : "O";
                    EndGame($"Победил игрок {winner}!");
                    return;
                }
            }

            for (int col = 0; col < boardSize; col++)
            {
                if (_cells[0, col].Image == _cells[1, col].Image &&
                    _cells[1, col].Image == _cells[2, col].Image &&
                    _cells[0, col].Image != null)
                {
                    string winner = _cells[0, col].Image == _images[0] ? "X" : "O";
                    EndGame($"Победил игрок {winner}!");
                    return;
                }
            }

            if (_cells[0, 0].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 2].Image &&
                _cells[0, 0].Image != null)
            {
                string winner = _cells[0, 0].Image == _images[0] ? "X" : "O";
                EndGame($"Победил игрок {winner}!");
                return;
            }

            if (_cells[0, 2].Image == _cells[1, 1].Image &&
                _cells[1, 1].Image == _cells[2, 0].Image &&
                _cells[0, 2].Image != null)
            {
                string winner = _cells[0, 2].Image == _images[0] ? "X" : "O";
                EndGame($"Победил игрок {winner}!");
                return;
            }

            if (_movesCount == boardSize * boardSize)
            {
                EndGame("Ничья!");
            }
        }

        private void EndGame(string result)
        {
            gameEnded = true;
            Logger.LogInfo($"Сетевая игра завершена: {result}");

            if (result.Contains("Победил игрок " + localPlayer.Symbol))
            {
                UpdateWins();
            }

            MessageBox.Show(result, "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                if (_isHost)
                    server?.Stop();
                else
                    client?.Disconnect();
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при закрытии соединения", ex);
            }

           
            if(result.Contains("Победил игрок " + localPlayer.Symbol))
            {
                var resultForm = new ResultForm("Победа!");
                resultForm.FormClosed += (s, args) => this.Close();
                resultForm.Show();
            }
            else if(!result.Contains("Победил игрок " + localPlayer.Symbol))
            {
                var resultForm = new ResultForm("Поражение!");
                resultForm.FormClosed += (s, args) => this.Close();
                resultForm.Show();
            }
            else
            {
                var resultForm = new ResultForm("Ничья!");
                resultForm.FormClosed += (s, args) => this.Close();
                resultForm.Show();
            }
        }

        private void UpdateWins()
        {
            try
            {
                if (CurrentUser.Instance != null)
                {
                    using (var db = new AppDbContext())
                    {
                        var user = db.Users.FirstOrDefault(u => u.Id == CurrentUser.Instance.Id);
                        if (user != null)
                        {
                            user.NumWins++;
                            db.SaveChanges();

                            CurrentUser.Instance = user;

                            Logger.LogInfo($"Обновлено количество побед для {user.Name}: {user.NumWins}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при обновлении количества побед", ex);
            }
        }

        private int GetRow(string cellName)
        {
            return int.Parse(cellName.Substring(cellName.Length - 5, 1));
        }

        private int GetCol(string cellName)
        {
            return int.Parse(cellName.Substring(cellName.Length - 4, 1));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                gameEnded = true;
                if (_isHost)
                    server?.Stop();
                else
                    client?.Disconnect();

                Logger.LogInfo("Сетевая игра закрыта");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при закрытии сетевой игры", ex);
            }

            base.OnFormClosed(e);
        }
    }
}
