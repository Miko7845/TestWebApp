using Aquality.Selenium.Browsers;

namespace WebApp.Utilities
{
    public static class Auth
    {
        public static string Authorize(string login, string pass) => "http://" + login + ":" + pass + "@" + AqualityServices.Browser.Driver.Url.Replace("http://", "");
    }
}
