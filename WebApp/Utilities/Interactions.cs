using Aquality.Selenium.Browsers;
using OpenQA.Selenium;

namespace WebApp.Utilities
{
    public class Interactions
    {
        public static void SendCookie(string key, string value) => AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie(key, value));
        public static string TakeScreenshot() => AqualityServices.Browser.Driver.GetScreenshot().AsBase64EncodedString;
    }
}
