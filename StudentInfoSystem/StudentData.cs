using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal static class StudentData
    {
        public static List<Student> TestStudents {  get; private set; }
        static StudentData()
        {
            TestStudents.Add(new Student { name = "Петър", surname = "Иванов", lastName = "Димитров", faculty = "ФКСТ", major = "ИТИ", degree = "Бакалавър", status = "действащ", facultyNumber = "501219999", year = "1", stream = "9", group = "99" });
        }
    }
}
