using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace WebApp.Forms.Pages
{
    public class ProjectPage : Form
    {
        private ILabel _projectId => ElementFactory.GetLabel(By.Id("projectId"), "Project Id", ElementState.ExistsInAnyState);
        private IList<ILabel> _listOfDate => ElementFactory.FindElements<ILabel>(By.XPath("//table[contains(@class, 'table')]//tr//td[4]"), "List of date(start test)");
        private IList<ILabel> _listOfName => ElementFactory.FindElements<ILabel>(By.XPath("//table[contains(@class, 'table')]//tr//td[2]"), "List of test name");

        public ProjectPage() : base(By.ClassName("table"), nameof(ProjectPage)) { }

        public string GetProjectId() => _projectId.GetAttribute("value");
        public bool IsTestAdded(string name) => AqualityServices.ConditionalWait.WaitFor(_ => _listOfName.Any(x => x.Text == name), pollingInterval: TimeSpan.FromSeconds(5));

        public List<DateTime> GetListOfDate()
        {
            AqualityServices.ConditionalWait.WaitFor(_=> _listOfDate.Count > 1, pollingInterval: TimeSpan.FromSeconds(5));
            return _listOfDate.Select(x => DateTime.ParseExact(x.Text, "yyyy-MM-dd HH:mm:ss.f", System.Globalization.CultureInfo.InvariantCulture)).ToList();
        }
    }
}
