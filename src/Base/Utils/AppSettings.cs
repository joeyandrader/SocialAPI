using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocialAPI.src.Base.Utils
{
    static class AppSettings
    {
        #region SQLConnectionString
        public static string SQLConnectionString { get; set; }
        #endregion

        #region JWT
        public static string JwtKey { get; set; }
        #endregion

        public static void LoadSettings(ConfigurationManager configuration)
        {
            SQLConnectionString = configuration.GetValue<string>("SqlConnectionString");
            JwtKey = configuration.GetValue<string>("Jwt:JwtKey");
        }
    }
}