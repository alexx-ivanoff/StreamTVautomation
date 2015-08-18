using System;
using System.Configuration;
using NUnit.Framework;
using Wrappers;

namespace Tests
{
    [TestFixture(BrowserType.API)]
    public class BaseFixtureAPI : TestFixtureBase
    {
        public BaseFixtureAPI(BrowserType browserType)
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
            InitializeSettings();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
        }
    }
}