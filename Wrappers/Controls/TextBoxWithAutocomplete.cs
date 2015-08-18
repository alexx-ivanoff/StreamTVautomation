using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Wrappers
{
    public class TextBoxWithAutocomplete : TextBox
    {
        internal TextBoxWithAutocomplete(IWebElement container)
            : base(container)
        {
        }

        public string Text
        {
            get
            {
                if (Container.TagName == "div")
                    return Container.Text;
                return Container.GetAttribute("value");
            }
            set
            {
                Clear();
                Container.SendKeys(value);
                new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(
                    ExpectedConditions.ElementExists(By.CssSelector("ul.dropdown-menu[aria-hidden=false]")));
                Container.SendKeys(Keys.Enter);
            }
        }
    }
}