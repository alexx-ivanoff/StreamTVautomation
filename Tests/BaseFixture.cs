using System;
using System.Configuration;
using NUnit.Framework;
using Wrappers;

namespace Tests
{
    //[TestFixture]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    public class BaseFixture : TestFixtureBase
    {
        public BaseFixture(BrowserType browserType)
            : base(browserType)
        {
        }

        [SetUp]
        public virtual void SetUp()
        {

        }

        [TearDown]
        public virtual void TearDown()
        {

        }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            InitializeDriver();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            CloseDriver();
        }
    }
}