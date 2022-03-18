using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    internal class Program
    {
        public static void ErrorMsg(string error)
            {
                Console.WriteLine(error);
            }
        public static void AdminMenu()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");
            Int32 option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 0:
                    //return;
                    break;
                case 1:
                    Console.WriteLine("Въведете потребителско име:");
                    String user = Console.ReadLine();
                    Console.WriteLine("Въведете новата роля на потребителя: ");
                    UserRoles role = (UserRoles) Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(user, role);
                    AdminMenu();
                    break;
                case 2:
                    Console.WriteLine("Въведете потребителско име:");
                    user = Console.ReadLine();
                    Console.WriteLine("Въведете срок на активност на потребителя: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(user, date);
                    AdminMenu();
                    break;
                case 3:
                    AdminMenu();
                    break;
                case 4:
                    IEnumerable<string> logs = Logger.GetLogActivity();
                    ViewActivity(logs);
                    AdminMenu();
                    break;
                case 5:
                    Console.WriteLine("Въведете филтър на търсенето: ");
                    string filter = Console.ReadLine();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                    ViewActivity(currentActs);
                    AdminMenu();
                    break;
                default:
                    Console.WriteLine("Невалидна опция!");
                    AdminMenu();
                    break;
            }
        }

        public static void ViewActivity(IEnumerable<string> activity)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string activityLine in activity) sb.Append(activityLine + Environment.NewLine);
            Console.WriteLine(sb.ToString());
        }

        static void Main(string[] args)
        {
            string un;
            string pw;
            Console.WriteLine("Username: ");
            un = Console.ReadLine();
            Console.WriteLine("Password: ");
            pw = Console.ReadLine();
            LoginValidation Log1 = new LoginValidation(un, pw, ErrorMsg);
            User newu = null;

            if (Log1.ValidateUserInput(ref newu))
            {
                Console.WriteLine("Име: {0}, Парола: {1}, Факултетен номер: {2}, Роля: {3}", newu.Username, newu.Password, newu.FacNum, newu.Role);
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Анонимен потребител");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Администратор");
                        AdminMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Инспектор");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Професор");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Студент");
                        break;
                    default:
                        Console.WriteLine("Несъществуваща роля!");
                        break;
                }
            }

        }
    }
}