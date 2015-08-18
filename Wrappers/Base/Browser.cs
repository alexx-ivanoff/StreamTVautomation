namespace Wrappers
{
    public class Browser
    {
        internal Browser()
        {
        }

        public void GoToUrl(string url)
        {
            Context.DefaultDriver.Navigate().GoToUrl(url);
        }
    }
}

public enum BrowserType
{
    Chrome,
    Firefox,
    API
}