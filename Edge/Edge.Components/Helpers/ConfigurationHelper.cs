using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.Components.Helpers
{
    public static class ConfigurationHelper
    {
        public static string SmtpHost
        {
            get { return ConfigurationManager.AppSettings["SmtpHost"].ToString(); }
        }
        public static int SmtpPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"].ToString()); }
        }
        public static string Email
        {
            get { return ConfigurationManager.AppSettings["Email"].ToString(); }
        }
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["Password"].ToString(); }
        }
        public static bool DebugLog
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["DebugLog"].ToString()); }
        }
        public static string LogFilePath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"].ToString()); }
        }
    }
}
