using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class LabWork : Task
    {
        Material labWork;
        Material answer;
        public LabWork(string course) : base(course)
        {
        }
    }
}
