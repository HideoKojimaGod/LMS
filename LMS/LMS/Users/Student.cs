using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Student : User
    {
        List<Course> Courses;
        public Group Group
        {
            get; set;
        }
        public Student(string login, string password, string firstName, string secondName, string lastName, string email) :
            base(login, password, firstName, secondName, lastName, email) { }

        public Course GetCourse(int index)
        {
            return Courses[index];
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }

    }
}
