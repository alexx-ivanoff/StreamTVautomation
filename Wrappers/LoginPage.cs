using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Wrappers
{
    public class LoginPage : Page
    {
        public TextBox UserName
        {
            get
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.CssSelector("input[type=text]")));
                return new TextBox(Driver.FindElement(By.CssSelector("input[type=text]")));
            }
        }

        public TextBox Password
        {
            get
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.CssSelector("input[type=password]")));
                return new TextBox(Driver.FindElement(By.CssSelector("input[type=password]")));
            }
        }

        public Button LoginButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("button[type=submit]"))); }
        }

        public void LogIn(string userName, string password)
        {
            UserName.Text = userName;
            Password.Text = password;
            LoginButton.Click();
        }
    }
}