using Microsoft.EntityFrameworkCore;
using TicTacToeGame.Classes;
using TicTacToeGame.Forms;

namespace TicTacToeGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Logger.LogInfo("Приложение запущено");
                Logger.ClearOldLogs(); 

                InitializeDatabase();

                ApplicationConfiguration.Initialize();
                Logger.LogInfo("Конфигурация приложения инициализирована");

                Application.Run(new FirstForm());
            }
            catch (Exception ex)
            {
                Logger.LogError("Критическая ошибка при запуске приложения", ex);
                MessageBox.Show($"Произошла критическая ошибка при запуске приложения:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.LogInfo("Приложение завершено");
            }
        }

        private static void InitializeDatabase()
        {
            try
            {
                Logger.LogInfo("Начало инициализации базы данных");

                string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                if (!Directory.Exists(dbDirectory))
                {
                    Directory.CreateDirectory(dbDirectory);
                    Logger.LogInfo($"Создана директория для базы данных: {dbDirectory}");
                }

                using (var db = new AppDbContext())
                {
                    Logger.LogInfo("Проверка существования базы данных");

                    bool dbExists = db.Database.CanConnect();
                    if (!dbExists)
                    {
                        Logger.LogInfo("База данных не существует. Создание базы данных...");
                        db.Database.EnsureCreated();
                        Logger.LogInfo("База данных успешно создана");
                    }
                    else
                    {
                        Logger.LogInfo("База данных уже существует");
                    }

                    Logger.LogInfo("Проверка и применение миграций");
                    var pendingMigrations = db.Database.GetPendingMigrations();
                    if (pendingMigrations.Any())
                    {
                        Logger.LogInfo($"Обнаружены ожидающие миграции: {string.Join(", ", pendingMigrations)}");
                        db.Database.Migrate();
                        Logger.LogInfo("Миграции успешно применены");
                    }
                    else
                    {
                        Logger.LogInfo("Ожидающих миграций не обнаружено");
                    }

                    if (!db.Users.Any())
                    {
                        Logger.LogInfo("Таблица Users пуста. Добавление тестового пользователя Admin");
                        db.Users.Add(new Model.User
                        {
                            Name = "Admin",
                            Email = "admin@example.com",
                            Password = HashPassword.Hash("admin123"),
                            NumWins = 0
                        });
                        db.SaveChanges();
                        Logger.LogInfo("Тестовый пользователь Admin успешно добавлен (логин: Admin, пароль: admin123)");
                    }
                    else
                    {
                        Logger.LogInfo($"В таблице Users найдено {db.Users.Count()} пользователей");
                    }
                }

                Logger.LogInfo("Инициализация базы данных успешно завершена");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при инициализации базы данных", ex);

                try
                {
                    Logger.LogInfo("Попытка принудительного создания базы данных");
                    using (var db = new AppDbContext())
                    {
                        db.Database.EnsureDeleted();
                        db.Database.EnsureCreated();

                        db.Users.Add(new Model.User
                        {
                            Name = "Admin",
                            Email = "admin@example.com",
                            Password = HashPassword.Hash("admin123"),
                            NumWins = 0
                        });
                        db.SaveChanges();
                        Logger.LogInfo("База данных принудительно пересоздана с тестовым пользователем");
                    }
                }
                catch (Exception innerEx)
                {
                    Logger.LogError("Критическая ошибка при создании базы данных", innerEx);
                    throw new Exception("Не удалось инициализировать базу данных. " + ex.Message, ex);
                }
            }
        }
    }
}
