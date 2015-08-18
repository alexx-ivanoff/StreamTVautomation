using OpenQA.Selenium;

namespace Wrappers
{
    public abstract class Page
    {
        internal IWebDriver Driver
        {
            get { return Context.Driver; }
        }

        public string URL
        {
            get { return Driver.Url; }
        }

        public Ribbon Ribbon
        {
            get { return new Ribbon(Driver.FindElement(By.CssSelector("ul.nav.nav-tabs"))); }
        }
    }
}