using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class User
    {
        protected string FirstName;
        protected string SecondName;
        protected string LastName;
        protected string Email;


        protected string password;
        protected string login;
        //Chat[] chats;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void ChangeSecondName(string secondName)
        {
            SecondName = secondName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        public void ChangePassword(string password)
        {
            this.password = password;
        }

        public void ChangeLogin(string login)
        {
            this.login = login;
        }
    }
}
