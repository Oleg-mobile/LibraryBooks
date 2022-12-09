using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryBooks.Utils
{
    public static class EncryptionUtils
    {
        public static string GenerateSalt()
        {
            // INFO: Соль должна быть от 8 до 16 символов
            var buffer = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            return Convert.ToBase64String(buffer);  // byte array to string
        }

        public static string EncodePasword(string password, string salt)
        {
            byte[] passBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            // INFO: Length - длина - имя существительное, значит это не метод, а чья-то характеристика => обращаемся через точку
            var bytes = new byte[passBytes.Length + saltBytes.Length];

            // INFO: Склейка массивов
            Buffer.BlockCopy(passBytes, 0, bytes, 0, passBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, bytes, passBytes.Length, saltBytes.Length);

            var hash = HashAlgorithm.Create("MD5");
            var hashBytes = hash.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
