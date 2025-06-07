namespace TicTacToeGame.Network_classes
{
    public class Player
    {
        public string Symbol { get; set; } 
        public bool IsHost { get; set; }

        public Player(string symbol, bool isHost)
        {
            Symbol = symbol;
            IsHost = isHost;
        }
    }
}
