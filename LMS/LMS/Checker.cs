using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMS
{
    static class Checker
    {

        static public void CheckLogin(string login)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(login)) throw new ArgumentException("Невозможно использовать данный логин");
        }
        static public void CheckPassword(string password)
        {
            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(password)) throw new ArgumentException("Невозможно использовать данный пароль");
        }

        static public void CheckEmail(string email)
        {
            string pattern = @"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email)) throw new ArgumentException("Неправильный формат почты");
        }

        static public void CheckName(string name)
        {
            string pattern = @"^[а-яА-ЯёЁa-zA-Z]+$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name)) throw new ArgumentException("Нельзя использовать данное имя");
        }

        static public void CheckName(params string[] names)
        {
            string pattern = @"^[а-яА-ЯёЁa-zA-Z]+$";
            Regex regex = new Regex(pattern);
            foreach (string name in names)
                if (!regex.IsMatch(name)) throw new ArgumentException("Нельзя использовать данное имя");
        }
    }
}
