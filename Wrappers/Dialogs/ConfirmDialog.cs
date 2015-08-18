using OpenQA.Selenium;

namespace Wrappers
{
    public class ConfirmDialog : ModalDialog
    {
        public ConfirmDialog(string additionalCondition = "")
            : base(additionalCondition)
        {
        }

        public Button YesButton
        {
            get { return new Button(Container.FindElement(By.CssSelector("button.btn-success"))); }
        }

        public Button NoButton
        {
            get { return new Button(Container.FindElement(By.CssSelector("button.btn-warning"))); }
        }

        public string Text
        {
            get { return Driver.FindElement(By.CssSelector("div.modal-body")).Text; }
        }
    }
}