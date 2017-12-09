using IntershipProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace IntershipProject.Models
{
    class AppLoggingChecker
    {
        public static async Task<String> IsUserExist(string Login, string Password)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, Password);

            OrdersEntities ordersEntities = new OrdersEntities();

            if (await DatabaseConnectionChecker.IsConnected())
            {
                if (ordersEntities.Employees.Where(e => e.Login.Equals(Login) && e.Password.Equals(hash)).Count() > 0)
                    return null;
                else
                    return "Пользователя с таким логином и паролем не существует.";
            }
            else
                return "Отсутствует подключение к БД.";
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
