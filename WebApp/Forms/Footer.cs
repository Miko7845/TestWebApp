using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace WebApp.Forms
{
    public class Footer : Form
    {
        private ILabel _variant => ElementFactory.GetLabel(By.XPath("//footer//span"), "Variant number");

        public Footer() : base(By.ClassName("footer"), nameof(Footer)) { }

        public string GetVariant() => _variant.Text;
    }
}
