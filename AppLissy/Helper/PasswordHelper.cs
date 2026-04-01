using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    public static class PasswordHelper
    {
        public static (byte[] Hash, byte[] Salt) EncrypPassword(string password)
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                10000,
                HashAlgorithmName.SHA256
            );

            byte[] hash = pbkdf2.GetBytes(32);

            return (hash, salt);
        }

        public static bool VerificarPassword(string password, byte[] hashGuardado, byte[] saltGuardado)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                saltGuardado,
                10000,
                HashAlgorithmName.SHA256
            );

            byte[] hashComparar = pbkdf2.GetBytes(32);

            return hashComparar.SequenceEqual(hashGuardado);
        }
    }
}
