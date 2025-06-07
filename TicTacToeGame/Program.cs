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
                Logger.LogInfo("���������� ��������");
                Logger.ClearOldLogs(); 

                InitializeDatabase();

                ApplicationConfiguration.Initialize();
                Logger.LogInfo("������������ ���������� ����������������");

                Application.Run(new FirstForm());
            }
            catch (Exception ex)
            {
                Logger.LogError("����������� ������ ��� ������� ����������", ex);
                MessageBox.Show($"��������� ����������� ������ ��� ������� ����������:\n{ex.Message}",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.LogInfo("���������� ���������");
            }
        }

        private static void InitializeDatabase()
        {
            try
            {
                Logger.LogInfo("������ ������������� ���� ������");

                string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                if (!Directory.Exists(dbDirectory))
                {
                    Directory.CreateDirectory(dbDirectory);
                    Logger.LogInfo($"������� ���������� ��� ���� ������: {dbDirectory}");
                }

                using (var db = new AppDbContext())
                {
                    Logger.LogInfo("�������� ������������� ���� ������");

                    bool dbExists = db.Database.CanConnect();
                    if (!dbExists)
                    {
                        Logger.LogInfo("���� ������ �� ����������. �������� ���� ������...");
                        db.Database.EnsureCreated();
                        Logger.LogInfo("���� ������ ������� �������");
                    }
                    else
                    {
                        Logger.LogInfo("���� ������ ��� ����������");
                    }

                    Logger.LogInfo("�������� � ���������� ��������");
                    var pendingMigrations = db.Database.GetPendingMigrations();
                    if (pendingMigrations.Any())
                    {
                        Logger.LogInfo($"���������� ��������� ��������: {string.Join(", ", pendingMigrations)}");
                        db.Database.Migrate();
                        Logger.LogInfo("�������� ������� ���������");
                    }
                    else
                    {
                        Logger.LogInfo("��������� �������� �� ����������");
                    }

                    if (!db.Users.Any())
                    {
                        Logger.LogInfo("������� Users �����. ���������� ��������� ������������ Admin");
                        db.Users.Add(new Model.User
                        {
                            Name = "Admin",
                            Email = "admin@example.com",
                            Password = HashPassword.Hash("admin123"),
                            NumWins = 0
                        });
                        db.SaveChanges();
                        Logger.LogInfo("�������� ������������ Admin ������� �������� (�����: Admin, ������: admin123)");
                    }
                    else
                    {
                        Logger.LogInfo($"� ������� Users ������� {db.Users.Count()} �������������");
                    }
                }

                Logger.LogInfo("������������� ���� ������ ������� ���������");
            }
            catch (Exception ex)
            {
                Logger.LogError("������ ��� ������������� ���� ������", ex);

                try
                {
                    Logger.LogInfo("������� ��������������� �������� ���� ������");
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
                        Logger.LogInfo("���� ������ ������������� ����������� � �������� �������������");
                    }
                }
                catch (Exception innerEx)
                {
                    Logger.LogError("����������� ������ ��� �������� ���� ������", innerEx);
                    throw new Exception("�� ������� ���������������� ���� ������. " + ex.Message, ex);
                }
            }
        }
    }
}
