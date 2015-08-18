using OpenQA.Selenium;

namespace Wrappers
{
    public abstract class ModalDialog
    {
        protected ModalDialog(string additionalCondition)
        {
            Container = Driver.FindElement(By.CssSelector("div.modal-dialog" + additionalCondition));
        }

        internal IWebElement Container { get; set; }

        internal IWebDriver Driver
        {
            get { return Context.Driver; }
        }
    }
}