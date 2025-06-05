namespace TicTacToeGame.Classes
{
    public class HashPassword
    {
        static public string Hash(string password)
        {
            return System.Security.Cryptography.SHA256.Create()
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                .Select(x => x.ToString("X2")).Aggregate((s1, s2) => s1 + s2);
        }
    }
}
