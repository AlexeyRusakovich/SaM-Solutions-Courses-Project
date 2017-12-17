using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace IntershipProject.ViewModels
{
    public class Validating
    {
        
        public static string ValidateStandartString(string standartString, int maxLength = 50, int minLength = 3)
        {
            if (string.IsNullOrEmpty(standartString))
                return "Строка " + standartString + " не должна быть пустой.";
            else if (standartString.Length < minLength || standartString.Length > maxLength)
                return "Длина строки " + standartString + " должна быть в пределе от " + minLength + " до " + maxLength + " символов.";
            else if (OnlyRussianOrEnglishWord(standartString.ToLower()))
                return "Допустимы символы только русского и английского алфавитов.";
            return null;
        }

        public static string ValidateLogin(string login, int minLength = 3, int maxLength = 50)
        {
            if (string.IsNullOrWhiteSpace(login))
                return "Поле не должно быть пустым.";
            else if (login.Length < minLength || login.Length > maxLength)
                return "Допустимая длина от " + minLength + " до " + maxLength + " символов.";
            return null;
        }

        private static bool OnlyRussianOrEnglishWord(string russianOrEnglishWord)
        {
            Regex regex = new Regex("^[а-я a-z]+$");
            if (!regex.IsMatch(russianOrEnglishWord))
                return true;
            return false;
        }  
        
        public static string ValidatePhoneNumber(string phoneNumber)
        {

            Regex VelcomNumbers = new Regex(@"^(8029[13469]|80447|37529[13469]|375447|37529[13469])\d{6}$");
            Regex MTCNumbers = new Regex(@"^(8029[2578]|80336|37529[2578]|375336|37529[2578]|375336)\d{6}$");
            Regex LifeNumbers = new Regex(@"^(8025|37525)\d{7}$");
            Regex Beltelecom = new Regex(@"^(801[567]|802[1234])\d{7}$");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return "Поле не должно быть пустым.";
            else if (VelcomNumbers.IsMatch(phoneNumber))
                return null;
            else if (MTCNumbers.IsMatch(phoneNumber))
                return null;
            else if (LifeNumbers.IsMatch(phoneNumber))
                return null;
            else if (Beltelecom.IsMatch(phoneNumber))
                return null;

            return "Допустимы номера только белорусских операторов";
        }

        public static string ValidateEmailAdress(string email)
        {
            Regex emailAdress = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (!emailAdress.IsMatch(email))
                return "Недопустимый email адресс.";
            return null;
        }

        public static string ValidateValue(string someValue, int minValue = 1, int maxValue = 1000)
        {
            int result = 0;
            bool isNumber = false;
            if (string.IsNullOrWhiteSpace(someValue))
                return "Поле не должно быть пустым.";
            if (!(isNumber = int.TryParse(someValue, out result)))
            {
                return "Значение должно быть числом.";
            }
            if (isNumber && result >= minValue && result <= maxValue)
                return null;
            else
                return "Зачение должно входить в диапазон от " + minValue + " до " + maxValue + '.';
        }

    }
}
