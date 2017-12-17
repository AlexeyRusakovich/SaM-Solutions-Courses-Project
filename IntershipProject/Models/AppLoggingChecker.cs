using IntershipProject;
using IntershipProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public delegate void OnAppLogin();

        public static event OnAppLogin onAppLogin;
        
        public static async Task<string> GetUserNameById(int id)
        {
            OrdersEntities ordersEntities = new OrdersEntities();
            var eList = await (from e in ordersEntities.Employees where e.EmployeeId.Equals(id) select e).ToListAsync();
            if (eList.Count() != 0)
                return eList.First().FirsName + ' ' + eList.First().LastName;
            else
                return "Default User";
        }

        public static async Task<System.String> IsUserExist(string Login, string Password)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, Password);

            OrdersEntities ordersEntities = new OrdersEntities();

            if (await DatabaseConnectionChecker.IsConnected())
            {
                var currentUserId =  await (from e in ordersEntities.Employees where e.Login.Equals(Login) && e.Password.Equals(hash) select e).ToListAsync();

                if (currentUserId.Count() != 0)
                {
                    MainViewModel.CurrentUserId = currentUserId.First().EmployeeId;
                    onAppLogin?.Invoke();
                    return null;
                }
                else
                    return "Неверное имя или пароль";
            }
            else
                return "Ошибка. Нет соединения с БД.";
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            
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
