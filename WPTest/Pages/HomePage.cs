using OpenQA.Selenium;
using WPTest.Extensions;
using WPTest.Models;

namespace WPTest.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl($"{BaseUrl}");
            IsPageDisplayed();
        }


        protected By _userName = By.Name("login");
        protected By _password = By.Name("password");
        protected By _login = By.XPath("//button[normalize-space()='Login']");
        protected By _register = By.XPath("//a[normalize-space()='Register']");
        protected By _popularMake = By.XPath("//img[@title='Lamborghini']");
        protected By _popularModel = By.XPath("//img[@title='Diablo']");
        protected By _overallRating = By.XPath("//img[@src='/img/overall.jpg']");
        public void UserName(string value) => Driver.FindElement(_userName).SendText(value);
        public void Password(string value) => Driver.FindElement(_password).SendText(value);
        public void IsPageDisplayed() => Driver.WaitUntilElementIsDisplay(_userName);
        public IWebElement Login => Driver.FindElement(_login);
        public IWebElement Register => Driver.FindElement(_register);
        public IWebElement PopularMake => Driver.FindByWithWait(_popularMake);
        public IWebElement PopularModel => Driver.FindByWithWait(_popularModel);
        public IWebElement OverallRating => Driver.FindByWithWait(_overallRating);
        public void LoginUser(User user)
        {
            UserName(user.Login);
            Password(user.Password);
            Login.Click();
        }

    }
}
