using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        Student GetStudentDataByUser(User user)
        {
            foreach (Student stud in StudentData.TestStudents)
            {
                if (stud.facultyNumber != null && stud.facultyNumber == user.FacNum)
                    return stud;
            }
            Console.WriteLine("Факултетният номер не е открит!");
            return null;
        }
    }
}
