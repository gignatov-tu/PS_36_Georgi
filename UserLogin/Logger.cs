using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> _currentSessionActivities = new List<string>();
        public static void LogActivity(string activity)
        {
            string activeLine = DateTime.Now + "; "
            + LoginValidation.currentUserUsername + "; "
            + LoginValidation.currentUserRole + "; "
            + activity;
            _currentSessionActivities.Add(activeLine);
            if (!File.Exists("log.txt"))
            {
                File.WriteAllText("log.txt", activeLine + Environment.NewLine);
            }
            else File.AppendAllText("log.txt", activeLine + Environment.NewLine);
        }
        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in _currentSessionActivities where activity.Contains(filter) select activity).ToList();
            return filteredActivities;
        }
        public static IEnumerable<string> GetLogActivity()
        {
            if (File.Exists("log.txt"))
            {
                return File.ReadAllLines("log.txt").ToList();
            }
            else return null;
        }
    }
}
