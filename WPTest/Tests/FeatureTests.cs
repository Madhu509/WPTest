using NUnit.Framework;
using WPTest.Dictionaries;
using WPTest.Pages;

namespace WPTest.Tests
{
    class FeatureTests : BaseTest
    {
        public FeatureTests(Browser browser, string version) : base(browser, version) { }

        HomePage homePage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
        }

        [Test]
        public void PopularMakeCheckColumnsTests()
        {
            homePage.PopularMake.Click();
            MakePage popularMake = new MakePage(Driver);
            popularMake.Model.Click();
            popularMake.Rank.Click();
            popularMake.Votes.Click();
            popularMake.Comments.Click();
            //Asertion 
            //Check sorting
        }

        [Test]
        public void PopularModelTests()
        {
            homePage.PopularModel.Click();
        }


        [Test]
        public void PopularOverallRatingTests()
        {
            homePage.OverallRating.Click();
        }

    }
}
