namespace TicTacToeGame.Network_classes
{
    public static class GameMessage
    {
        public const string PREFIX = "T3:";

        public static string Move(int row, int col)
        {
            return $"{PREFIX}MOVE:{row},{col}";
        }

        public static string ParseMove(string message, out int row, out int col)
        {
            var parts = message.Substring(3).Split(':');
            var coords = parts[1].Split(',');

            row = int.Parse(coords[0]);
            col = int.Parse(coords[1]);

            return parts[0]; 
        }

        public static string GameOver(string result)
        {
            return $"{PREFIX}END:{result}";
        }

        public static string ParseGameOver(string message, out string result)
        {
            var parts = message.Substring(3).Split(':');
            result = parts[1];
            return parts[0]; 
        }
    }
}
