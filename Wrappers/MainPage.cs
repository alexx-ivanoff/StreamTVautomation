using OpenQA.Selenium;

namespace Wrappers
{
    public class MainPage : Page
    {
        public Button NewButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("button[ng-click='newWrestler()']"))); }
        }

        public Button SearchButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("button[ng-click='searchWrestler(searchFor)']"))); }
        }

        public TextBox SearchCondition
        {
            get { return new TextBox(Driver.FindElement(By.CssSelector("input[ng-model=searchFor]"))); }
        }

        public Grid SearchResults
        {
            get { return new Grid(Driver.FindElement(By.CssSelector("table.table-striped"))); }
        }

        public ComboBox RegionFilter
        {
            get { return new ComboBox(Driver.FindElement(By.CssSelector("select[ng-model='filters.fregion']"))); }
        }

        public ComboBox FstFilter
        {
            get { return new ComboBox(Driver.FindElement(By.CssSelector("select[ng-model='filters.ffst']"))); }
        }

        public ComboBox YearFilter
        {
            get { return new ComboBox(Driver.FindElement(By.CssSelector("select[ng-model='filters.fyear']"))); }
        }

        public ComboBox PhotoFilter
        {
            get { return new ComboBox(Driver.FindElement(By.CssSelector("select[ng-model='filters.fphoto']"))); }
        }

        public ComboBox StyleFilter
        {
            get { return new ComboBox(Driver.FindElement(By.CssSelector("select[ng-model='filters.fstyle']"))); }
        }
    }
}