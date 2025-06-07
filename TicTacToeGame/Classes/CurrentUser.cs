using TicTacToeGame.Model;

namespace TicTacToeGame.Models
{
    public static class CurrentUser
    {
        public static User Instance { get; set; }
        public static User User => Instance;

        public static void SetCurrentUser(User user)
        {
            Instance = user;
        }
    }
}
