using OpenQA.Selenium;

namespace Wrappers
{
    public class Row : Control
    {
        internal Row(IWebElement container)
            : base(container)
        {
        }

        public string ID
        {
            get { return Driver.FindElements(By.CssSelector("td"))[0].Text; }
        }

        public string FIO
        {
            get { return Driver.FindElements(By.CssSelector("td"))[1].Text; }
        }

        public string FST
        {
            get { return Driver.FindElements(By.CssSelector("td"))[2].Text; }
        }

        public string License
        {
            get { return Driver.FindElements(By.CssSelector("td"))[3].Text; }
        }

        public string Photo
        {
            get { return Driver.FindElements(By.CssSelector("td"))[4].Text; }
        }

        public string Style
        {
            get { return Driver.FindElements(By.CssSelector("td"))[5].Text; }
        }

        public string Changed
        {
            get { return Driver.FindElements(By.CssSelector("td"))[6].Text; }
        }

        public void Select()
        {
            Container.Click();
        }
    }
}