using System.Security.Cryptography;
using System.Text;

namespace TicTacToeGame.Classes
{
    public static class HashPassword
    {
        public static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Join("", hashBytes.Select(b => b.ToString("X2")));
            }
        }

        public static bool Verify(string password, string hash)
        {
            string computedHash = Hash(password);
            return computedHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
