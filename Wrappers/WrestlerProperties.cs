using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace Wrappers
{
    public class WrestlerProperties : Page
    {
        public Button SuccessButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("button.btn-success"))); }
        }

        public Button DeleteButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("button.btn-danger"))); }
        }

        public TextBox LastName
        {
            get { return new TextBox(Driver.FindElement(By.CssSelector("input[placeholder='Last name']"))); }
        }

        public TextBox FirstName
        {
            get { return new TextBox(Driver.FindElement(By.CssSelector("input[placeholder='First name']"))); }
        }

        public TextBox DateOfBirth
        {
            get { return new TextBox(Driver.FindElement(By.CssSelector("input[placeholder='Date of Birth']"))); }
        }

        public TextBox MiddleName
        {
            get { return new TextBox(Driver.FindElement(By.CssSelector("input[placeholder='Middle name']"))); }
        }

        public TextBoxWithAutocomplete Trainer1
        {
            get
            {
                return
                    new TextBoxWithAutocomplete(Driver.FindElements(By.CssSelector("input[placeholder='Trainer']"))[0]);
            }
        }

        public TextBoxWithAutocomplete Trainer2
        {
            get
            {
                return
                    new TextBoxWithAutocomplete(Driver.FindElements(By.CssSelector("input[placeholder='Trainer']"))[1]);
            }
        }

        public ComboBox Region1
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.region1']/descendant::select")));
            }
        }

        public ComboBox Region2
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.region2']/descendant::select")));
            }
        }

        public ComboBox FST1
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.fst1']/descendant::select")));
            }
        }

        public ComboBox FST2
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.fst2']/descendant::select")));
            }
        }

        public ComboBox Style
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.style']/descendant::select")));
            }
        }

        public ComboBox Age
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.lictype']/descendant::select")));
            }
        }

        public ComboBox Year
        {
            get
            {
                return new ComboBox(Driver.FindElement(By.XPath("//fg-select[@value='wr.expires']/descendant::select")));
            }
        }

        public ComboBox Card
        {
            get
            {
                return
                    new ComboBox(Driver.FindElement(By.XPath("//f-select[@value='wr.card_state']/descendant::select")));
            }
        }

        public Button ChoosePhotoButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("input[uploader=photoUploader]"))); }
        }

        public Button ChooseAttachButton
        {
            get { return new Button(Driver.FindElement(By.CssSelector("input[uploader=attachUploader]"))); }
        }

        public void UploadFile(string path)
        {
            ChoosePhotoButton.Click();
            Thread.Sleep(100);
            SendKeys.SendWait(path);
            SendKeys.SendWait("{ENTER}");
        }

        public void DeleteWrestler()
        {
            DeleteButton.Click();
            var confirmDialog = new ConfirmDialog();
            confirmDialog.YesButton.Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(t => Ribbon.CurrentTab.Name == "Wrestlers");
        }
    }
}