using NUnit.Framework;
using Wrappers;

namespace Tests
{
    internal class Level2 : BaseFixture
    {
        public Level2(BrowserType browserType)
      : base(browserType)
        {
        }

        [SetUp]
        public virtual void SetUp()
        {
            //open website in browser
            Context.Browser.GoToUrl(Context.Settings.HostLink);

            //login
            var loginPage = new LoginPage();
            loginPage.LogIn(Context.Settings.UserName, Context.Settings.UserPassword);
        }

        [Test]
        [Ignore]
        [Description("Upload photo to the wrester")]
        public void L2T01_UploadPhoto()
        {
            var mainPage = new MainPage();
            var wrestler = ApiHelper.CreateRandomWrestler();
            mainPage.SearchCondition.Text = wrestler.LastName;
            mainPage.SearchButton.Click();
            mainPage.SearchResults.Rows[0].Select();
            var wrestlerProperties = new WrestlerProperties();
            wrestlerProperties.UploadFile("");
            //wrestlerProperties.ChoosePhotoButton.Click();
        }
    }
}