using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Common
{
    public static class SystemSettings
    {
        public static string ApiKey => ConfigurationManager.AppSettings["ApiKey"];
        public static string ApiSecret => ConfigurationManager.AppSettings["ApiSecret"];
        public static string ApiHost => ConfigurationManager.AppSettings["ApiHost"];
        public static string RedirectUrl => ConfigurationManager.AppSettings["RedirectUrl"];
        public static string UninstallUrl => ConfigurationManager.AppSettings["UninstallUrl"];
    }
}
