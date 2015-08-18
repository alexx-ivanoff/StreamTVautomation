using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace Wrappers
{
    public class Ribbon : Control
    {
        internal Ribbon(IWebElement container)
            : base(container)
        {
        }

        public Collection<RibbonTab> Tabs
        {
            get
            {
                //var tabs = Container.FindElements(By.CssSelector("tab-heading.ng-scope"));
                var tabs = Container.FindElements(By.CssSelector("li.ng-isolate-scope"));
                return new Collection<RibbonTab>(tabs.Select(tab => new RibbonTab(tab)).ToArray());
            }
        }

        public RibbonTab CurrentTab
        {
            get { return new RibbonTab(Container.FindElement(By.CssSelector("li.ng-isolate-scope.active"))); }
        }


        public void SelectTabByName(string value)
        {
            ((RibbonTab)Tabs.Select(t => t.Name == value)).Click();
        }


        public void CloseCurrentTab()
        {
            CurrentTab.Close();
        }
    }
}