using AngleSharp.Dom;
using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using WebApp.Forms;
using WebApp.Forms.Pages;
using WebApp.Utilities;

namespace WebApp.Test.Tests
{
    public class Tests : BaseWebTest
    {
        [Test]
        public void Test()
        {
            var token = RequestUtil.GetToken();
            Assert.IsTrue(!string.IsNullOrEmpty(token), "The token has not been generated.");

            AqualityServices.Browser.Driver.Navigate().GoToUrl(Auth.Authorize(TestData.Login, TestData.Password));
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.WaitForDisplayed(), $"{mainPage.Name} should be presented");
            Interactions.SendCookie(TestData.CookieKey, token);
            AqualityServices.Browser.Refresh();

            var footer = new Footer();
            Assert.AreEqual(TestData.Version, footer.GetVariant(), "Versions do not match.");

            mainPage.GoToProject(TestData.Nexage);
            var nexage = new ProjectPage();
            Assert.IsTrue(nexage.State.WaitForDisplayed(), $"{nexage.Name} should be presented");
            var tests = RequestUtil.GetTestsByJson(nexage.GetProjectId());

            var startDate = nexage.GetListOfDate();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(ValidateClass.IsDateTimeListInOrder(startDate), "Date not sorted");
                Assert.IsTrue(startDate.All(x => tests.Select(y => y.StartTime).Contains(x)), "The tests don't match.");
            });

            AqualityServices.Browser.GoBack();
            Assert.IsTrue(mainPage.State.WaitForDisplayed(), $"{mainPage.Name} should be presented");
            mainPage.AddProject();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            var addProject = new AddProjectPage();

            string projectName = RandomData.GetRandomString();
            addProject.SetAndSaveProjectName(projectName);
            StringAssert.Contains(TestData.SuccessAlert, addProject.GetSuccessText(), "Success alert did not appear");
            AqualityServices.Browser.Tabs().CloseTab();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            AqualityServices.Browser.Refresh();

            mainPage.GoToProject(projectName);
            var customProject = new ProjectPage();
            Assert.IsTrue(customProject.State.WaitForDisplayed(), $"{customProject.Name} should be presented");
            var testId = RequestUtil.CreateTest(DateTime.Now.ToString(), projectName, nameof(Test), nameof(Test), Environment.MachineName);
            RequestUtil.SendLogs(testId, File.ReadAllText(TestData.LogsPath));
            RequestUtil.SendAttachment(testId, Interactions.TakeScreenshot(), TestData.ScreenshotType);

            Assert.IsTrue(customProject.IsTestAdded(nameof(Test)), "The test didn't show up.");
        }
    }
}