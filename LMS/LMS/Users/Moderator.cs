using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Moderator : User
    {
        public Moderator(string login, string password, string firstName, string secondName, string lastName, string email) :
            base(login, password, firstName, secondName, lastName, email) { }


    }
}
