
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppMysql.Server
{
    public class Conf
    {
        private static IHttpContextAccessor _HttpContextAccessor;

        public Conf(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public static IConfigurationBuilder Getbuilder()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            return builder;
        }

        public static string GetAppSetting(string key)
        {
            //return Convert.ToString(ConfigurationManager.AppSettings[key]);
            var builder = Getbuilder();
            var GetAppStringData = builder.Build().GetValue<string>(  key);
            return GetAppStringData;
        }

   
    }
}