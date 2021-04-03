using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WPTest.Models;
using WPTest.Pages;

namespace WPTest.Bdd.Steps
{
    [Binding]
    public class RegistrationTestSteps
    {

        IWebDriver driver;
        HomePage homePage;
        RegistrationPage registrationPage;
        private readonly ScenarioContext _scenarioContext;

        public RegistrationTestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = (IWebDriver)_scenarioContext["Driver"];
        }


        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {

            homePage = new HomePage(driver);
            registrationPage = new RegistrationPage(driver);
        }

        [Given(@"Click registration button")]
        public void GivenClickRegistrationButton()
        {
            homePage.Register.Click();
        }

        [When(@"I submit user details for registration (.*),(.*),(.*),(.*),(.*)")]
        public void WhenISubmitUserDetailsForRegistrationAbcAbc_ComJohnLinTestingTesting(string login, string firstname, string lastname, string password, string confirmpassword)
        {
            User userDetails = new User(login, firstname, lastname, password, confirmpassword);
            registrationPage.EnterUserRegistrationDetails(userDetails);
        }

        [Then(@"User should be registered successfully")]
        public void ThenUserShouldBeRegisteredSuccessfully()
        {
            registrationPage.GetRegistrationMessage.Should().Be(registrationPage.successMessage);
        }
    }
}
