using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntMoodleRooms
{
    public class clsWSConfig
    {
        public static string url = ConfigurationManager.AppSettings["url"];
        
        public static string token = ConfigurationManager.AppSettings["token"];

        public static string BusinessUnit = ConfigurationManager.AppSettings["business-unit"];

        public static string wsUser = "user.php";
        public static string wsCourse = "course.php";
        public static string wsEnroll = "enroll.php";

    }
}
