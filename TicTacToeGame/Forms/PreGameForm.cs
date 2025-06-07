using TicTacToeGame.Models;
using TicTacToeGame.Classes;

namespace TicTacToeGame.Forms
{
    public partial class PreGameForm : Form
    {
        public PreGameForm()
        {
            InitializeComponent();

            if (CurrentUser.Instance != null)
            {
                Logger.LogInfo($"PreGameForm открыта для пользователя: {CurrentUser.Instance.Name}");

                try
                {
                    using (var db = new AppDbContext())
                    {
                        var user = db.Users.FirstOrDefault(u => u.Id == CurrentUser.Instance.Id);
                        if (user != null)
                        {
                            CurrentUser.Instance.NumWins = user.NumWins;
                            stars_lbl.Text = user.NumWins.ToString();
                            Logger.LogInfo($"Обновлено количество побед для пользователя {user.Name}: {user.NumWins}");
                        }
                        else
                        {
                            Logger.LogWarning("Текущий пользователь не найден в базе данных");
                            stars_lbl.Text = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError("Ошибка при обновлении количества побед пользователя", ex);
                    stars_lbl.Text = CurrentUser.Instance.NumWins.ToString();
                }
            }
            else
            {
                Logger.LogWarning("PreGameForm открыта без залогиненного пользователя");
                stars_lbl.Text = "0";
            }
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Начата одиночная игра");
            using (var form = new SingleGameForm())
            {
                form.ShowDialog();
            }
        }

        private void acc_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Открыта форма профиля");
            using (var form = new ProfileForm())
            {
                form.ProfileExit += (s, ev) =>
                {
                    Logger.LogInfo("Выход из профиля, закрытие PreGameForm");
                    Close();
                };

                form.ShowDialog();
            }
        }

        private void playNetwork_btn_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Начата сетевая игра");
            var choiceForm = new ChoiceForm();

            choiceForm.Show();
            Hide();

            choiceForm.FormClosed += (s, args) =>
            {
                Logger.LogInfo("ChoiceForm закрыта, возврат к PreGameForm");
                Show();
            };
        }
    }
}
