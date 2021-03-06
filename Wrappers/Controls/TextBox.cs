﻿using OpenQA.Selenium;

namespace Wrappers
{
    public class TextBox : Control
    {
        internal TextBox(IWebElement container)
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
            }
        }

        public bool Enabled
        {
            get { return Container.Enabled; }
        }

        public void Clear()
        {
            Container.Clear();
        }
    }
}