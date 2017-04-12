using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Teacher : User
    {

        List<Course> Courses;
        List<Group> Groups;
        public Teacher(string login, string password, string firstName, string secondName, string lastName, string email) :
            base(login, password, firstName, secondName, lastName, email) { }


        public Course GetCourse(int index)
        {
            return Courses[index];
        }

        public Group GetGroup(int index)
        {
            return Groups[index];
        }


        public void SetCourse(int index, Course course)
        {
            Courses[index] = course;
        }

        public void SetGroup(int index, Group group)
        {
            Groups[index] = group;
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            Groups.Remove(group);
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
