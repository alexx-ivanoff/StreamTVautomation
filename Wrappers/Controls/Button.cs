using OpenQA.Selenium;

namespace Wrappers
{
    public class Button : Control
    {
        internal Button(IWebElement container)
            : base(container)
        {
        }

        public string Text
        {
            get { return Container.Text; }
        }

        public virtual void Click()
        {
            Container.Click();
        }

        public bool Enabled
        {
            get { return Container.GetAttribute("disabled") != "true"; }
        }
    }
}