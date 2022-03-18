using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;
        public static List<User> TestUsers
        {
            get 
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);
                _testUsers.Add(new User { Username = "bobi22", Password = "123456a", FacNum = "50505050", Role = 1, Created = DateTime.Now, ActiveUntil = DateTime.MaxValue });
                _testUsers.Add(new User { Username = "bobi23", Password = "123456a", FacNum = "50505050", Role = 4, Created = DateTime.Now, ActiveUntil = DateTime.MaxValue });
                _testUsers.Add(new User { Username = "bobi24", Password = "123456a", FacNum = "50505050", Role = 4, Created = DateTime.Now, ActiveUntil = DateTime.MaxValue });
            }
        }

        public static User IsUserPassCorrect(String username, String password)
        {
            return (from user in TestUsers where user.Username == username && user.Password == password select user).First();
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            foreach (User user in TestUsers)
            {
                if (username == user.Username)
                {
                    user.ActiveUntil = date;
                    Logger.LogActivity("Промяна на активност на " + username);
                }
            }
        }
        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (User user in TestUsers)
            {
                if (username == user.Username) 
                { 
                    user.Role = (int)role;
                    Logger.LogActivity("Промяна на роля на " + username);
                }

            }
        }

    }
}
