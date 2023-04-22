using System.Security.Cryptography;

namespace WalletAppBackend.Services.Business
{
    public class PasswordService
    {
        public static string GeneratePasswordHash(string password, byte[] salt)
        {
            int iterations = 10000;
            int hashLength = 32; // 256 bits

            // Create a new instance of Rfc2898DeriveBytes for this thread
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);
            byte[] hash = pbkdf2.GetBytes(hashLength);
            return Convert.ToBase64String(hash);
        }
    }
}
