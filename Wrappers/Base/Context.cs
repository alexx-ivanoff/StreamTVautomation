using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using OpenQA.Selenium;

namespace Wrappers
{
    public static class Context
    {
        internal static IWebDriver DefaultDriver
        {
            get
            {
                Driver.SwitchTo().DefaultContent();
                return Driver;
            }
            set { Driver = value; }
        }

        public static IWebDriver Driver { get; set; }
        public static Browser Browser { get; internal set; }

        private static void CloseProcess(string name)
        {
            foreach (var process in Process.GetProcesses().Where(p => p.ProcessName.Contains(name)))
                process.Kill();
        }

        public static void CloseDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }

            CloseProcess("chromedriver");
        }

        public static void CloseBrowsers()
        {
            CloseProcess("chrome");
            CloseProcess("firefox");
        }

        public static class Settings
        {
            static Settings()
            {
                WaitTimeout = 10000;
            }

            public static int WaitTimeout { get; set; }
            public static string HostLink { get; internal set; }

            public static string Domain
            {
                get { return new Uri(HostLink).Host.ToString(); }
            }
            public static string UserName { get; internal set; }
            public static string UserPassword { get; internal set; }
        }
    }
}