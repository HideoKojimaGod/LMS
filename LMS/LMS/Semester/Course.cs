using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Course
    {
        string CourseName;
        List<Teacher> Teachers;
        List<Student> Students;
        List<Material> Materials;
        List<Test> Tests;
        List<LabWork> LabWorks;

        public Course(string courseName)
        {
            CourseName = courseName;
        }

       public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

       public void AddMaterial(Material material)
        {
            Materials.Add(material);
        }

        public void AddTest(Test test)
        {
            Tests.Add(test);
        }





     }
}
