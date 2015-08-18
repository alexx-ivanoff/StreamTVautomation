using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Wrappers
{
    public class ComboBox : Control
    {
        private readonly SelectElement _selectElement;

        internal ComboBox(IWebElement container)
            : base(container)
        {
            _selectElement = new SelectElement(container);
        }

        public int SelectByText(string text)
        {
            var isExist = _selectElement.Options.Any(s => s.Text == text);
            if (!isExist)
                throw new Exception(String.Format("Element '{0}' was not found in combobox.", text));
            _selectElement.SelectByText(text);

            var valueFull = _selectElement.Options.FirstOrDefault(s => s.Text == text).GetAttribute("value");
            return int.Parse(valueFull.Replace("string:", ""));
        }


        public string SelectByValue(int value)
        {
            var valueFull = String.Format("string:{0}", value);
            var isExist = _selectElement.Options.Any(s => s.GetAttribute("value") == valueFull);
            if (!isExist)
                throw new Exception(String.Format("Element with value '{0}' was not found in combobox.", valueFull));
            _selectElement.SelectByValue(valueFull);

            return _selectElement.Options.FirstOrDefault(s => s.GetAttribute("value") == valueFull).Text;
        }

        /*
        public void SelectByIndex(int index)
        {
            var count = _selectElement.Options.Count();
            if (index >= count)
                throw new Exception(String.Format("Cannot select {0} element - combobox has only {1} elements.", index, count));
            _selectElement.SelectByIndex(index);
        }
        
        public void SelectFirst()
        {
            var count = _selectElement.Options.Count();
            if (count > 0)
                throw new Exception("Cannot select first element - combobox hasn't elements at all.");
            _selectElement.SelectByIndex(0);
        }

        public void SelectLast()
        {
            var count = _selectElement.Options.Count();
            if (count > 0)
                throw new Exception("Cannot select last element - combobox hasn't elements at all.");
            _selectElement.SelectByIndex(count - 1);
        }
        */
        public string Selected
        {
            get
            {
                return _selectElement.SelectedOption.Text;
            }
        }
    }
}