using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wrappers;

namespace Tests
{
    internal class Level3 : BaseFixtureAPI
    {
        public Level3(BrowserType browserType)
        : base(browserType)
        {
        }

        [Test]
        [Description("CRUD wrestler")]
        public void L3T01_CRUD()
        {
            //create wrestler
            var lastName = String.Format("Burton{0}{1}t{2}", DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Millisecond);
            var firstName = "Cliff";
            var dateOfBirth = "10-02-1962";
            var middleName = "Lee";
            var region1id = 12;
            var region2id = 13;
            var fst1id = 3;
            var fst2id = 4;
            var trainer1id = 556;
            var trainer2id = 557;
            var styleId = 2;
            var ageId = 2;
            var year = 2015;
            var cardId = 2;

            var wrestler = new WrestlerEntity();
            wrestler.LastName = lastName;
            wrestler.FirstName = firstName;
            wrestler.MiddleName = middleName;
            wrestler.DateOfBirth = dateOfBirth;
            wrestler.Region1id = region1id;
            wrestler.Region2id = region2id;
            wrestler.Fst1id = fst1id;
            wrestler.Fst2id = fst2id;
            wrestler.Trainer1id = trainer1id;
            wrestler.Trainer2id = trainer2id;
            wrestler.StyleId = styleId;
            wrestler.AgeId = ageId;
            wrestler.Year = year;
            wrestler.CardId = cardId;
            var id = API.CreateWrestler(wrestler);
            wrestler.ID = id;

            //read created wrestler
            var readedWrestler = API.ReadWrestler(id);
            Assert.AreEqual(wrestler.LastName, API.ReadWrestler(readedWrestler.ID).LastName, "Wrestler wasn't created.");

            //check fields
            var exceptions = new List<string>();
            if (wrestler.LastName != readedWrestler.LastName) exceptions.Add("Last name was not saved properly.");
            if (wrestler.FirstName != readedWrestler.FirstName) exceptions.Add("First name was not saved properly.");
            if (wrestler.MiddleName != readedWrestler.MiddleName) exceptions.Add("Middle name was not saved properly.");
            if (wrestler.DateOfBirth != readedWrestler.DateOfBirth)
                exceptions.Add("Date of Birth was not saved properly.");
            if (wrestler.Region1id != readedWrestler.Region1id) exceptions.Add("Region1 was not saved properly.");
            if (wrestler.Region2id != readedWrestler.Region2id) exceptions.Add("Region2 was not saved properly.");
            if (wrestler.Fst1id != readedWrestler.Fst1id) exceptions.Add("Fst1 was not saved properly.");
            if (wrestler.Fst2id != readedWrestler.Fst2id) exceptions.Add("Fst2 was not saved properly.");
            if (wrestler.Trainer1id != readedWrestler.Trainer1id) exceptions.Add("Trainer1 was not saved properly.");
            if (wrestler.Trainer2id != readedWrestler.Trainer2id) exceptions.Add("Trainer2 was not saved properly.");
            if (wrestler.StyleId != readedWrestler.StyleId) exceptions.Add("Style was not saved properly.");
            if (wrestler.AgeId != readedWrestler.AgeId) exceptions.Add("Age was not saved properly.");
            if (wrestler.Year != readedWrestler.Year) exceptions.Add("Year was not saved properly.");
            if (wrestler.CardId != readedWrestler.CardId) exceptions.Add("Card was not saved properly.");

            //update wrestler
            var lastNameUp = String.Format("Hetfield{0}{1}t{2}", DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Millisecond);
            var firstNameUp = "James";
            var dateOfBirthUp = "03-08-1963";
            var middleNameUp = "Alan";
            var region1idUp = 14;
            var region2idUp = 16;
            var fst1idUp = 5;
            var fst2idUp = 6;
            var trainer1idUp = 557;
            var trainer2idUp = 556;
            var styleIdUp = 3;
            var ageIdUp = 3;
            var yearUp = 2014;
            var cardIdUp = 3;

            wrestler.LastName = lastNameUp;
            wrestler.FirstName = firstNameUp;
            wrestler.MiddleName = middleNameUp;
            wrestler.DateOfBirth = dateOfBirthUp;
            wrestler.Region1id = region1idUp;
            wrestler.Region2id = region2idUp;
            wrestler.Fst1id = fst1idUp;
            wrestler.Fst2id = fst2idUp;
            wrestler.Trainer1id = trainer1idUp;
            wrestler.Trainer2id = trainer2idUp;
            wrestler.StyleId = styleIdUp;
            wrestler.AgeId = ageIdUp;
            wrestler.Year = yearUp;
            wrestler.CardId = cardIdUp;

            API.UpdateWrestler(wrestler);

            //read updated wrestler
            readedWrestler = API.ReadWrestler(id);

            //check updated wrestlers
            if (wrestler.LastName != readedWrestler.LastName) exceptions.Add("Last name was not updated properly.");
            if (wrestler.FirstName != readedWrestler.FirstName) exceptions.Add("First name was not updated properly.");
            if (wrestler.MiddleName != readedWrestler.MiddleName)
                exceptions.Add("Middle name was not updated properly.");
            if (wrestler.DateOfBirth != readedWrestler.DateOfBirth)
                exceptions.Add("Date of Birth was not updated properly.");
            if (wrestler.Region1id != readedWrestler.Region1id) exceptions.Add("Region1 was not updated properly.");
            if (wrestler.Region2id != readedWrestler.Region2id) exceptions.Add("Region2 was not updated properly.");
            if (wrestler.Fst1id != readedWrestler.Fst1id) exceptions.Add("Fst1 was not updated properly.");
            if (wrestler.Fst2id != readedWrestler.Fst2id) exceptions.Add("Fst2 was not updated properly.");
            if (wrestler.Trainer1id != readedWrestler.Trainer1id) exceptions.Add("Trainer1 was not updated properly.");
            if (wrestler.Trainer2id != readedWrestler.Trainer2id) exceptions.Add("Trainer2 was not updated properly.");
            if (wrestler.StyleId != readedWrestler.StyleId) exceptions.Add("Style was not updated properly.");
            if (wrestler.AgeId != readedWrestler.AgeId) exceptions.Add("Age was not updated properly.");
            if (wrestler.Year != readedWrestler.Year) exceptions.Add("Year was not updated properly.");
            if (wrestler.CardId != readedWrestler.CardId) exceptions.Add("Card was not updated properly.");

            //delete wrestler
            API.DeleteWrestler(id);

            //try to read updated wrestler
            readedWrestler = API.ReadWrestler(id);
            if (readedWrestler != null) exceptions.Add("Wrestler was not deleted.");

            Assert.That(exceptions.Count == 0, String.Join("\r\n", exceptions.ToArray()));
        }
    }
}