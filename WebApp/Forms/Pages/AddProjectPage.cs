using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace WebApp.Forms.Pages
{
    public class AddProjectPage : Form
    {
        private ITextBox _projectNameBox => ElementFactory.GetTextBox(By.Id("projectName"), "Project name textbox");
        private IButton _save => ElementFactory.GetButton(By.XPath("//button[contains(@type, 'submit')]"), "Save button");
        private ILabel _successAlert => ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'alert-success')]"), "Success text");

        public AddProjectPage() : base(By.Id("projectName"), nameof(AddProjectPage)) { }

        private void SetProjectName(string name) => _projectNameBox.SendKeys(name);
        private void SaveProjectName() => _save.Click();

        public void SetAndSaveProjectName(string name)
        {
            SetProjectName(name);
            SaveProjectName();
        }

        public string GetSuccessText() => _successAlert.Text;
    }
}
