using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Wrappers
{
    public class TestFixtureBase
    {
        public readonly BrowserType BrowserType;

        public TestFixtureBase(BrowserType browserType)
        {
            BrowserType = browserType;
        }

        public virtual void InitializeDriver()
        {
            InitializeSettings();

            switch (BrowserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(new string[] { "--no-sandbox", "test-type", "--start-maximized" });
                    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = false;
                    Context.Driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(300.0));
                break;
                case BrowserType.Firefox:
                    var capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(CapabilityType.UnexpectedAlertBehavior, "dismiss");
                    Context.Driver = new FirefoxDriver(capabilities);
                break;

            }

            Context.Browser = new Browser();
            Context.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(Context.Settings.WaitTimeout));
            Context.Driver.Navigate().GoToUrl("about:blank");
            Context.Driver.SwitchTo().Window(Context.Driver.WindowHandles.First());
        }


/*
        public virtual void InitializeDriver()
        {
            InitializeSettings();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--no-sandbox", "test-type", "--start-maximized");
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = false;
            Context.Driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(300.0));

            Context.Browser = new Browser();
            Context.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(Context.Settings.WaitTimeout));
            Context.Driver.Navigate().GoToUrl("about:blank");
            Context.Driver.SwitchTo().Window(Context.Driver.WindowHandles.First());
        }
*/

        public virtual void InitializeSettings()
        {
            Context.Settings.HostLink = ConfigurationManager.AppSettings["Server"];
            Context.Settings.UserName = ConfigurationManager.AppSettings["UserName"];
            Context.Settings.UserPassword = ConfigurationManager.AppSettings["UserPassword"];
        }

        public virtual void CloseDriver()
        {
            Context.CloseDriver();
        }
    }
}