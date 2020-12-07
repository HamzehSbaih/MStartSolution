using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.Common.Utilities
{
    public class AppSettings
    {

        public static string LogFilePath => GetValue("LogFilePath");
        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static bool DisableHandleWebExceptions => GetValue("DisableHandleWebExceptions") == "1";
    }
}
