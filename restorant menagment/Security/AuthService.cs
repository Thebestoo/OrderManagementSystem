using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OrderManagementSystem.Security
{
    public static class AuthService
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var saltedPassword = passwordBytes.Concat(salt).ToArray();
                byte[] hash = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string passwordAttempt, string storedHash)
        {
            var parts = storedHash.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordAttempt);
            byte[] saltedPassword = passwordBytes.Concat(salt).ToArray();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashAttempt = sha256.ComputeHash(saltedPassword);
                string hashAttemptString = Convert.ToBase64String(hashAttempt);
                return hashAttemptString == parts[1];
            }
        }
    }
}
