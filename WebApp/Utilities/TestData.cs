using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace WebApp.Utilities
{
    public static class TestData
    {
        private static ISettingsFile _testingData => new JsonSettingsFile($"Resources.TestData.json", Assembly.GetCallingAssembly());

        public static string Login => _testingData.GetValue<string>("login");
        public static string Password => _testingData.GetValue<string>("password");
        public static string CookieKey => _testingData.GetValue<string>("cookieKey");
        public static string Version => _testingData.GetValue<string>("version");
        public static string Nexage => _testingData.GetValue<string>("nexage");
        public static string SuccessAlert => _testingData.GetValue<string>("successAlert");
        public static string LogsPath => _testingData.GetValue<string>("logsPath");
        public static string ScreenshotType => _testingData.GetValue<string>("screenshotType");
    }
}
