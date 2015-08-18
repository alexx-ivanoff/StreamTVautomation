using OpenQA.Selenium;

namespace Wrappers
{
    public class RibbonTab : Control
    {
        internal RibbonTab(IWebElement container)
            : base(container)
        {
        }

        public string Name
        {
            get { return Container.Text; }
        }

        public void Click()
        {
            Container.Click();
        }

        public void Close()
        {
            //var closeButton = new Button(Container.FindElement(By.CssSelector("div.close-it")));
            var closeButton = new Button(Container.FindElement(By.CssSelector("ico[class='']")));
            if (closeButton != null)
                closeButton.Click();
        }
    }
}