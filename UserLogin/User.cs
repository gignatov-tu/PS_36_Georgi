using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public String Username{ get; set; }
        public String Password{ get; set; }
        public String FacNum{ get; set; }
        public Int32 Role{ get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveUntil { get; set; }
    }
}
