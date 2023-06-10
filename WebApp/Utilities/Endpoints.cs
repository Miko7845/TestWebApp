using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace WebApp.Utilities
{
    public static class Endpoints
    {
        private static ISettingsFile _endpoints => new JsonSettingsFile($"Resources.Api.Endpoints.json", Assembly.GetCallingAssembly());

        public static string Put => _endpoints.GetValue<string>("put");
        public static string GetCsv => _endpoints.GetValue<string>("getCsv");
        public static string Update => _endpoints.GetValue<string>("update");
        public static string PutLog => _endpoints.GetValue<string>("putLog");
        public static string GetToken => _endpoints.GetValue<string>("getToken");
        public static string PutAttachment => _endpoints.GetValue<string>("putAttachment");
        public static string UpdateAuthor => _endpoints.GetValue<string>("updateAuthor");
        public static string GetJson => _endpoints.GetValue<string>("getJson");
        public static string UpdateDevInfo => _endpoints.GetValue<string>("updateDevInfo");
        public static string GetXml => _endpoints.GetValue<string>("getXml");
    }
}
