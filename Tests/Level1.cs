using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Wrappers;

namespace Tests
{
    public class Level1 : BaseFixture
    {
        public Level1(BrowserType browserType)
        : base(browserType)
        {
        }

        [SetUp]
        public void SetUp()
        {
            //open website in browser
            Context.Browser.GoToUrl(Context.Settings.HostLink);

            //login
            var loginPage = new LoginPage();
            loginPage.LogIn(Context.Settings.UserName, Context.Settings.UserPassword);
        }

        [Test]
        [Description("Create, Search, Update and Delete wrestler")]
        public void L1T01_CreateAndSearchWrestler()
        {
            var lastName = String.Format("Burton{0}{1}t{2}", DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Millisecond);
            var firstName = "Cliff";
            var dateOfBirth = "10-02-1962";
            var middleName = "Lee";
            var region1 = "Vynnitska";
            var region2 = "Volynska";
            var fst1 = "Dinamo";
            var fst2 = "Kolos";
            var trainer1 = "Trainer1 T.T.";
            var trainer2 = "Trainer2 T.T.";
            var style = "FW";
            var age = "Senior";
            var year = "2016";
            var card = "Produced";

            var lastNameUp = String.Format("Hetfield{0}{1}t{2}", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Millisecond);
            var firstNameUp = "James";
            var dateOfBirthUp = "03-08-1963";
            var middleNameUp = "Alan";
            var region1Up = "Lvivska";
            var region2Up = "Odeska";
            var fst1Up = "MON";
            var fst2Up = "ZSU";
            var trainer1Up = "Trainer2 T.T.";
            var trainer2Up = "Trainer1 T.T.";
            var styleUp = "GR";
            var ageUp = "Cadet";
            var yearUp = "2014";
            var cardUp = "Recieved";

            //  >>> create wrestler
            var mainPage = new MainPage();

            //click New Wrestler button
            mainPage.NewButton.Click();

            //fill all fields
            var wrestlerProperties = new WrestlerProperties();

            wrestlerProperties.LastName.Text = lastName;
            wrestlerProperties.FirstName.Text = firstName;
            wrestlerProperties.DateOfBirth.Text = dateOfBirth;
            wrestlerProperties.MiddleName.Text = middleName;
            wrestlerProperties.Region1.SelectByText(region1);
            wrestlerProperties.Region2.SelectByText(region2);
            wrestlerProperties.FST1.SelectByText(fst1);
            wrestlerProperties.FST2.SelectByText(fst2);
            wrestlerProperties.Trainer1.Text = trainer1;
            wrestlerProperties.Trainer2.Text = trainer2;
            wrestlerProperties.Style.SelectByText(style);
            wrestlerProperties.Age.SelectByText(age);
            wrestlerProperties.Year.SelectByText(year);
            wrestlerProperties.Card.SelectByText(card);

            //save wrestler
            wrestlerProperties.SuccessButton.Click();
            Assert.That(false == wrestlerProperties.SuccessButton.Enabled, "Wrestler was not saved.");
            wrestlerProperties.Ribbon.CloseCurrentTab();


            //search wrestler
            mainPage.SearchCondition.Text = lastName;
            mainPage.SearchButton.Click();
            Assert.That(0 < mainPage.SearchResults.Count, "Wrestler was not found.");
            Assert.That(
                String.Format("{0} {1} {2}", lastName, firstName, middleName) == mainPage.SearchResults.Rows[0].FIO,
                "Wrestler was not found.");
            var id = mainPage.SearchResults.Rows[0].ID;
            try
            {
                mainPage.SearchResults.Rows[0].Select();
                wrestlerProperties = new WrestlerProperties();

                //verify fields
                var exceptions = new List<string>();
                if (lastName != wrestlerProperties.LastName.Text) exceptions.Add("Last name is wrong.");
                if (firstName != wrestlerProperties.FirstName.Text) exceptions.Add("First name is wrong.");
                if (dateOfBirth != wrestlerProperties.DateOfBirth.Text) exceptions.Add("Date of Birth is wrong.");
                if (middleName != wrestlerProperties.MiddleName.Text) exceptions.Add("Middle name is wrong.");
                if (region1 != wrestlerProperties.Region1.Selected) exceptions.Add("Region1 is wrong.");
                if (region2 != wrestlerProperties.Region2.Selected) exceptions.Add("Region2 is wrong.");
                if (fst1 != wrestlerProperties.FST1.Selected) exceptions.Add("FST1 is wrong.");
                if (fst2 != wrestlerProperties.FST2.Selected) exceptions.Add("FST1 is wrong.");
                if (trainer1 != wrestlerProperties.Trainer1.Text) exceptions.Add("Trainer1 is wrong.");
                if (trainer2 != wrestlerProperties.Trainer2.Text) exceptions.Add("Trainer2 is wrong.");
                if (style != wrestlerProperties.Style.Selected) exceptions.Add("Style is wrong.");
                if (age != wrestlerProperties.Age.Selected) exceptions.Add("Age is wrong.");
                if (year != wrestlerProperties.Year.Selected) exceptions.Add("Year is wrong.");
                if (card != wrestlerProperties.Card.Selected) exceptions.Add("Card is wrong.");

                //update wrestler
                wrestlerProperties.LastName.Text = lastNameUp;
                wrestlerProperties.FirstName.Text = firstNameUp;
                wrestlerProperties.DateOfBirth.Text = dateOfBirthUp;
                wrestlerProperties.MiddleName.Text = middleNameUp;
                wrestlerProperties.Region1.SelectByText(region1Up);
                wrestlerProperties.Region2.SelectByText(region2Up);
                wrestlerProperties.FST1.SelectByText(fst1Up);
                wrestlerProperties.FST2.SelectByText(fst2Up);
                wrestlerProperties.Trainer1.Text = trainer1Up;
                wrestlerProperties.Trainer2.Text = trainer2Up;
                wrestlerProperties.Style.SelectByText(styleUp);
                wrestlerProperties.Age.SelectByText(ageUp);
                wrestlerProperties.Year.SelectByText(yearUp);
                wrestlerProperties.Card.SelectByText(cardUp);

                //save wrestler
                wrestlerProperties.SuccessButton.Click();
                wrestlerProperties.Ribbon.CloseCurrentTab();

                //search and open updated wrestler
                SearchWrestler(lastNameUp, mainPage);
                mainPage.SearchResults.Rows[0].Select();
                wrestlerProperties = new WrestlerProperties();
                
                //verify fields
                if (lastNameUp != wrestlerProperties.LastName.Text) exceptions.Add("Updated Last name is wrong.");
                if (firstNameUp != wrestlerProperties.FirstName.Text) exceptions.Add("Updated First name is wrong.");
                if (dateOfBirthUp != wrestlerProperties.DateOfBirth.Text) exceptions.Add("Updated Date of Birth is wrong.");
                if (middleNameUp != wrestlerProperties.MiddleName.Text) exceptions.Add("Updated Middle name is wrong.");
                if (region1Up != wrestlerProperties.Region1.Selected) exceptions.Add("Updated Region1 is wrong.");
                if (region2Up != wrestlerProperties.Region2.Selected) exceptions.Add("Updated Region2 is wrong.");
                if (fst1Up != wrestlerProperties.FST1.Selected) exceptions.Add("Updated FST1 is wrong.");
                if (fst2Up != wrestlerProperties.FST2.Selected) exceptions.Add("Updated FST1 is wrong.");
                if (trainer1Up != wrestlerProperties.Trainer1.Text) exceptions.Add("Updated Trainer1 is wrong.");
                if (trainer2Up != wrestlerProperties.Trainer2.Text) exceptions.Add("Updated Trainer2 is wrong.");
                if (styleUp != wrestlerProperties.Style.Selected) exceptions.Add("Updated Style is wrong.");
                if (ageUp != wrestlerProperties.Age.Selected) exceptions.Add("Updated Age is wrong.");
                if (yearUp != wrestlerProperties.Year.Selected) exceptions.Add("Updated Year is wrong.");
                if (cardUp != wrestlerProperties.Card.Selected) exceptions.Add("Updated Card is wrong.");

                //delete wrestler
                wrestlerProperties.DeleteButton.Click();
                var confirmDialog = new ConfirmDialog();
                confirmDialog.YesButton.Click();

                //check wrestler was deleted
                if (API.SearchWrestlers(id).Count != 0) exceptions.Add("Wrestler was not deleted.");

                Assert.That(exceptions.Count == 0, String.Join("\r\n", exceptions.ToArray()));
            }
            finally
            {
                API.DeleteWrestler(id);
            }
        }
        
        [Test]
        [Description("Create wrestler, search him and verify all fields")]
        public void L1T02_Filters()
        {
            //setup preconditions
            var wrestler1 = ApiHelper.CreateRandomWrestler();
            var wrestler2 = ApiHelper.CreateRandomWrestler();
            var wrestler3 = ApiHelper.CreateRandomWrestler();
            try
            {
                var lastNamePrefix = String.Format("FilterTest{0}w", DateTime.Now.ToString("yyMMddHHmmssffff"));
                var lastName1 = lastNamePrefix + "1";
                var lastName2 = lastNamePrefix + "2";
                var lastName3 = lastNamePrefix + "3";

                var styleId1 = 2;
                var styleId2 = 3;
                var year1 = 2014;
                var year2 = 2015;

                wrestler1.LastName = lastName1;
                wrestler1.StyleId = styleId1;
                wrestler1.Year = year1;
                API.UpdateWrestler(wrestler1);

                wrestler2.LastName = lastName2;
                wrestler2.StyleId = styleId2;
                wrestler2.Year = year2;
                API.UpdateWrestler(wrestler2);

                wrestler3.LastName = lastName3;
                wrestler3.StyleId = styleId1;
                wrestler3.Year = year2;
                API.UpdateWrestler(wrestler3);

                //search without filters
                var mainPage = new MainPage();
                mainPage.SearchCondition.Text = lastNamePrefix;
                mainPage.SearchButton.Click();
                Assert.That(3 == mainPage.SearchResults.Count, "Wrong number of wrestlers was found.");

                var exceptions = new List<string>();

                //search with Year filter
                mainPage.YearFilter.SelectByText(year1.ToString());
                mainPage.SearchButton.Click();
                var searchResults = mainPage.SearchResults;
                if (searchResults.Count != 1) exceptions.Add("Wrong number of wrestlers was filtered by Year filter.");
                if (searchResults.Rows.Count(r => r.FIO == wrestler1.FIO) != 1)
                    exceptions.Add("Wrong wrestlers were filtered by Year filter.");

                //search with another value of Year filter
                mainPage.YearFilter.SelectByText(year2.ToString());
                mainPage.SearchButton.Click();
                searchResults = mainPage.SearchResults;
                if (searchResults.Count != 2) exceptions.Add("Wrong number of wrestlers was filtered by Year filter.");
                if (searchResults.Rows.Count(r => r.FIO == wrestler2.FIO || r.FIO == wrestler3.FIO) != 2)
                    exceptions.Add("Wrong wrestlers were filtered by Year filter.");

                //search with Style filter
                mainPage.StyleFilter.SelectByValue(styleId1);
                mainPage.SearchButton.Click();
                searchResults = mainPage.SearchResults;
                if (searchResults.Count != 1)
                    exceptions.Add("Wrong number of wrestlers was filtered by Year and Style filters.");
                if (searchResults.Rows.Count(r => r.FIO == wrestler3.FIO) != 1)
                    exceptions.Add("Wrong wrestlers were filtered by Year and Style filters.");

                Assert.That(exceptions.Count == 0, String.Join("\r\n", exceptions.ToArray()));
            }
            finally
            {
                API.DeleteWrestler(wrestler1.ID);
                API.DeleteWrestler(wrestler2.ID);
                API.DeleteWrestler(wrestler3.ID);
            }
        }

        #region Helpers

        private void CreateWrestler(WrestlerEntity wrestler, MainPage mainPage)
        {
            mainPage.NewButton.Click();
            var wrestlerProperties = new WrestlerProperties();

            wrestlerProperties.LastName.Text = wrestler.LastName;
            wrestlerProperties.FirstName.Text = wrestler.FirstName;
            wrestlerProperties.DateOfBirth.Text = wrestler.DateOfBirth;
            wrestlerProperties.MiddleName.Text = wrestler.MiddleName;
            wrestlerProperties.Region1.SelectByText(wrestler.Region1name);
            wrestlerProperties.Region2.SelectByText(wrestler.Region2name);
            wrestlerProperties.FST1.SelectByText(wrestler.Fst1name);
            wrestlerProperties.FST2.SelectByText(wrestler.Fst2name);
            wrestlerProperties.Trainer1.Text = wrestler.Trainer1name;
            wrestlerProperties.Trainer2.Text = wrestler.Trainer2name;
            wrestlerProperties.Style.SelectByText(wrestler.StyleName);
            wrestlerProperties.Age.SelectByText(wrestler.AgeName);
            wrestlerProperties.Year.SelectByText(wrestler.Year.ToString());
            wrestlerProperties.Card.SelectByText(wrestler.CardName);

            //save wrestler
            wrestlerProperties.SuccessButton.Click();
            Assert.That(false == wrestlerProperties.SuccessButton.Enabled, "Wrestler was not saved.");
            wrestlerProperties.Ribbon.CloseCurrentTab();
        }

        private void SearchWrestler(WrestlerEntity wrestler, MainPage mainPage)
        {
            mainPage.SearchCondition.Text = wrestler.LastName;
            mainPage.SearchButton.Click();
            Assert.That(0 < mainPage.SearchResults.Count, "Wrestler was not found.");
            Assert.That(
                String.Format("{0} {1} {2}", wrestler.LastName, wrestler.FirstName, wrestler.MiddleName) ==
                mainPage.SearchResults.Rows[0].FIO,
                "Wrestler was not found.");
        }

        private void SearchWrestler(string lastName, MainPage mainPage)
        {
            mainPage.SearchCondition.Text = lastName;
            mainPage.SearchButton.Click();
            Assert.That(0 < mainPage.SearchResults.Count, "Wrestler was not found.");
        }

        #endregion
    }
}