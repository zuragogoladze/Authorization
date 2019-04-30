using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Authorization.Core.Infrastructure
{
    public static class Helpers
    {
        public static string GetPasswordHash(string password, string salt)
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
