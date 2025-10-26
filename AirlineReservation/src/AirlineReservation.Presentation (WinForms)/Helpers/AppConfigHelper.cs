using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Helpers
{
    internal class AppConfigHelper
    {
        private static readonly IConfigurationRoot _config;

        static AppConfigHelper()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name)
                ?? throw new Exception($"Không tìm thấy connection string '{name}' trong appsettings.json");
        }
    }
}
