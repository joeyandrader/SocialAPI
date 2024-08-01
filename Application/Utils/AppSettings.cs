
using Microsoft.Extensions.Configuration;

namespace Application.Utils
{
    public static class AppSettings
    {


        #region PostgreSQL connection
        public static string? ConnectionString { get; set; }
        #endregion

        public static void LoadSettings(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionStrings:postgres"];
        }
    }
}
