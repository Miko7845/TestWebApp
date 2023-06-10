using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace WebApp.Forms.Pages
{
    public class MainPage : Form
    {
        private IButton _addProject => ElementFactory.GetButton(By.XPath("//div[contains(@class, 'panel-heading')]//*[contains(@class, 'pull-right')]"), "Add project button");
        private IList<IButton> _listOfProjects => ElementFactory.FindElements<IButton>(By.XPath("//div[contains(@class, 'list-group')]//*"), "List of projects");

        public MainPage() : base(By.ClassName("list-group"), nameof(MainPage)) { }

        public void AddProject() => _addProject.Click();
        public void GoToProject(string projectName) => _listOfProjects.FirstOrDefault(x => x.Text == projectName).Click();
    }
}
