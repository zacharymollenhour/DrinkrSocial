using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Helpers
{
    public static class AuthenticationHelper
    {
        // Function that creates the hash for an account
        public static (byte[] passwordHash, byte[] passwordSalt) CreateHash(string password)
        {
            using var hmac = new HMACSHA512();
            return (
                passwordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                passwordSalt: hmac.Key);
        }

        // Function that validates a hash for a account
        public static bool VerifyHash(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (var i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != hash[i])
                    return false;

            return true;
        }

        // Function that generates a random string to be used when hashing
        public static string GenerateRandomString(int length, bool createGuid = true)
        {
            var randomstring = new string(Enumerable
           .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
           .Select(x =>
           {
               var cryptoResult = new byte[4];
               using (var cryptoProvider = RandomNumberGenerator.Create())
                   cryptoProvider.GetBytes(cryptoResult);
               return x[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(x.Length)];
           })
           .ToArray());
            if (createGuid)
                return randomstring + Guid.NewGuid().ToString().Replace("-", "");
            else
                return randomstring;
        }
    }
}
