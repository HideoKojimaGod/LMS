using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class User
    {
        protected string FirstName;
        protected string SecondName;
        protected string LastName;
        protected string Email;


        protected string Password;
        protected string Login;
        //Chat[] chats;


        public User(string login, string password, string firstName, string secondName, string lastName, string email)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Email = email;
        }


        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
            FirstNameChanged(firstName);
        }

        public event Action<string> FirstNameChanged;


        public void ChangeSecondName(string secondName)
        {
            Parser.ChangeData("usersInfo.txt", SecondName, secondName, Login);
            SecondName = secondName;
            SecondNameChanged(secondName);
        }

        public event Action<string> SecondNameChanged;


        public void ChangeLastName(string lastName)
        {
            Parser.ChangeData("usersInfo.txt", LastName, lastName, Login);
            LastName = lastName;
            LastNameChanged(lastName);
        }

        public event Action<string> LastNameChanged;

        public void ChangePassword(string password)
        {
            Parser.ChangeData("dataIn.txt", Password, password, Login);
            this.Password = password;
            PasswordChanged(password);
        }

        public event Action<string> PasswordChanged;


        public void ChangeLogin(string login)
        {
            this.Login = login;
            LoginChanged(login);
        }

        public event Action<string> LoginChanged;

        public void ChangeEmail(string email)
        {
            Parser.ChangeData("usersInfo.txt", Email, email, Login);
            this.Email = email;
            EmailChanged(email);
        }

        public event Action<string> EmailChanged;

        public string GetEmail()
        {
            return Email;
        }
        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetSecondName()
        {
            return SecondName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetLogin()
        {
            return Login;
        }

        public string GetPassword()
        {
            return Password;
        }

        public static List<string> GetPersonalInfo(string fileName, string login)
        {
            var usersInfo = Parser.Read("usersInfo.txt");
            if(usersInfo.ContainsKey(login))
            {
                return usersInfo[login];
            }
            else
            {
                throw new ArgumentException("У данного пользователя нет персональных данных");
            }
        }

        public static void CheckDataIn(string filename, string login, string password)
        {
            var users = Parser.ReadDataIn(filename);
            if (users.ContainsKey(login))
            {
                if (!users.ContainsValue(password))
                    throw new ArgumentException("Неверный пароль");
            }
            else
            {
                throw new ArgumentException("Данного пользователя не существует");
            }
        }
    }
}
