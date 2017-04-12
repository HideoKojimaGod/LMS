using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Task
    {
        protected string course;

        public Task(string course)
        {
            this.course = course;
        }
        public string GetCourse()
        {
            return course;
        }
        public void SetCourse(string course)
        {
            this.course = course;
        }
    }
}
