using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace WebApp.Utilities
{
    public static class ApiConfig
    {
        private static ISettingsFile _options => new JsonSettingsFile($"Resources.Api.options.json", Assembly.GetCallingAssembly());

        public static string Variant => _options.GetValue<string>("variant");
    }
}
