using TicTacToeGame.Classes;
using TicTacToeGame.Models;

namespace TicTacToeGame.Forms
{
    public partial class ChoiceForm : Form
    {
        private string currentHostIP;
        private int currentPort;
        public ChoiceForm()
        {
            InitializeComponent();
            Logger.LogInfo("Форма выбора игры открыта");
        }

        private void host_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogInfo("Создание сетевой игры (хост)");

                string localIP = NetworkHelper.GetLocalIPAddress();
                int port = NetworkHelper.FindAvailablePort(12345);

                currentHostIP = localIP;
                currentPort = port;

                Logger.LogInfo($"Создание игры на {localIP}:{port}");

                MessageBox.Show($"Игра создана!\n\nВаш IP: {localIP}\nПорт: {port}\n\nСообщите IP второму игроку для подключения.",
                    "Сервер запущен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var gameForm = new NetworkGameForm(true, localIP, port);
                Hide();
                gameForm.Show();

                gameForm.FormClosed += (s, args) =>
                {
                    Logger.LogInfo("NetworkGameForm (хост) закрыта");
                    Close();
                };
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка создания сетевой игры", ex);
                MessageBox.Show($"Ошибка создания игры: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void client_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogInfo("Поиск сетевой игры (клиент)");

                client_btn.Enabled = false;
                host_btn.Enabled = false;
                client_btn.Text = "Поиск...";

                string hostIP = await FindLocalHost();
                int port = 12345; 

                if (!string.IsNullOrEmpty(hostIP))
                {
                    Logger.LogInfo($"Найден хост: {hostIP}:{port}");
                    MessageBox.Show($"Найдена игра!\nПодключение к {hostIP}:{port}...",
                        "Игра найдена", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var gameForm = new NetworkGameForm(false, hostIP, port);
                    Hide();
                    gameForm.Show();

                    gameForm.FormClosed += (s, args) =>
                    {
                        Logger.LogInfo("NetworkGameForm (клиент) закрыта");
                        ResetButtons();
                        Close();
                    };
                }
                else
                {
                    Logger.LogInfo("Хосты не найдены в локальной сети");

                    var result = MessageBox.Show("Игры не найдены в локальной сети.\n\nВвести IP адрес вручную?",
                        "Поиск не удался", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string manualIP = PromptForIP();
                        if (!string.IsNullOrEmpty(manualIP))
                        {
                            Logger.LogInfo($"Подключение к введенному IP: {manualIP}:{port}");

                            var gameForm = new NetworkGameForm(false, manualIP, port);
                            Hide();
                            gameForm.Show();

                            gameForm.FormClosed += (s, args) =>
                            {
                                Logger.LogInfo("NetworkGameForm (клиент) закрыта");
                                Show();
                                ResetButtons();
                            };
                        }
                        else
                        {
                            ResetButtons();
                        }
                    }
                    else
                    {
                        ResetButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка поиска сетевой игры", ex);
                MessageBox.Show($"Ошибка поиска игры: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetButtons();
            }
        }

        private async Task<string> FindLocalHost()
        {
            try
            {
                Logger.LogInfo("Начат поиск хостов в локальной сети");

                string networkBase = NetworkHelper.GetLocalNetworkBase();
                Logger.LogInfo($"Поиск в сети: {networkBase}.x");

                var quickCheckIPs = new[]
                {
                    $"{networkBase}.1",   
                    $"{networkBase}.100", 
                    $"{networkBase}.101",
                    $"{networkBase}.102",
                    $"{networkBase}.10",
                    $"{networkBase}.20",
                    $"{networkBase}.50"
                };

                foreach (string ip in quickCheckIPs)
                {
                    if (await NetworkHelper.IsGameHostReachable(ip, 12345))
                    {
                        Logger.LogInfo($"Быстро найден хост: {ip}");
                        return ip;
                    }
                }

                Logger.LogInfo("Хосты не найдены в локальной сети");
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка поиска хостов в локальной сети", ex);
                return null;
            }
        }

        private string PromptForIP()
        {
            try
            {
                string input = "";

                var inputForm = new Form()
                {
                    Width = 350,
                    Height = 180,
                    Text = "Введите IP адрес",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var label = new Label()
                {
                    Left = 20,
                    Top = 20,
                    Text = "IP адрес хоста:",
                    Width = 200
                };

                var textBox = new TextBox()
                {
                    Left = 20,
                    Top = 50,
                    Width = 250,
                    Text = NetworkHelper.GetLocalNetworkBase() + ".100"
                };

                var okButton = new Button()
                {
                    Text = "Подключиться",
                    Left = 180,
                    Width = 90,
                    Top = 90,
                    DialogResult = DialogResult.OK
                };

                var cancelButton = new Button()
                {
                    Text = "Отмена",
                    Left = 80,
                    Width = 90,
                    Top = 90,
                    DialogResult = DialogResult.Cancel
                };

                okButton.Click += (sender, e) =>
                {
                    input = textBox.Text.Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        MessageBox.Show("Введите IP адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    inputForm.Close();
                };

                cancelButton.Click += (sender, e) => { inputForm.Close(); };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.Controls.Add(cancelButton);
                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                return inputForm.ShowDialog() == DialogResult.OK ? input : null;
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка диалога ввода IP", ex);
                return null;
            }
        }

        private void ResetButtons()
        {
            client_btn.Enabled = true;
            host_btn.Enabled = true;
            client_btn.Text = "Найти игру";
        }

        private void ChoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.LogInfo("Форма выбора игры закрыта");


           if (CurrentUser.Instance != null)
            {
                SessionManager.LogoutUser(CurrentUser.Instance.Id);
                Logger.LogInfo($"Завершена сессия пользователя: {CurrentUser.Instance.Name}");
            }

            Application.Exit();
        }
    }
}
