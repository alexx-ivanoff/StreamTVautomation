using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Wrappers
{
    public abstract class Control
    {
        protected Control(IWebElement container)
        {
            Container = container;
        }

        internal IWebElement Container { get; set; }

        internal IWebDriver Driver
        {
            get { return ((RemoteWebElement) Container).WrappedDriver; }
        }
    }
}