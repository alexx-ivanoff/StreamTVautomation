using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace Wrappers
{
    public class Grid : Control
    {
        internal Grid(IWebElement container)
            : base(container)
        {
        }

        public Collection<Row> Rows
        {
            get
            {
                var rows = Container.FindElements(By.CssSelector("tr.ng-scope"));
                return new Collection<Row>(rows.Select(r => new Row(r)).ToArray());
            }
        }

        public int Count
        {
            get { return Rows.Count;  }
        }
    }
}