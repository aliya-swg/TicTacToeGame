using Microsoft.EntityFrameworkCore;

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
            using (var context = new AppDbContext())
            {
                context.Database.Migrate();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FirstForm());
        }
    }
}