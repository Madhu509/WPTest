using OpenQA.Selenium;
using WPTest.Extensions;
using WPTest.Models;

namespace WPTest.Pages
{
    class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver) { }
        protected By _login => By.Id("username");
        protected By _firstName => By.Id("firstName");
        protected By _lastName => By.Id("lastName");
        protected By _password => By.Id("password");
        protected By _confirmPassword => By.Id("confirmPassword");
        protected By _register => By.XPath("//button[normalize-space()='Register']");

        protected By _logout => By.XPath("//a[normalize-space()='Logout']");
        protected By _profile => By.XPath("//a[normalize-space()='Profile']");
        protected By _cancel => By.XPath("//a[normalize-space()='Cancel']");
        protected By _alertMessage => By.XPath("//div[contains(@class,'result alert')]");


        public string successMessage = "Registration is successful";

        public string alreadyExistsMessage = "UsernameExistsException: User already exists";
        public IWebElement Register => Driver.FindByWithWait(_register);

        public IWebElement Cancel => Driver.FindElement(_cancel);

        public IWebElement Profile => Driver.FindByWithWait(_profile);
        public IWebElement Logout => Driver.FindByWithWait(_logout);
        public void Login(string value) => Driver.FindByWithWait(_login).SendText(value);

        public void FirstName(string value) => Driver.FindElement(_firstName).SendText(value);

        public void LastName(string value) => Driver.FindElement(_lastName).SendText(value);

        public void Password(string value) => Driver.FindElement(_password).SendText(value);

        public void ConfirmPassword(string value) => Driver.FindElement(_confirmPassword).SendText(value);

        public string GetRegistrationMessage => Driver.FindElement(_alertMessage).Text;

        public void EnterUserRegistrationDetails(User user)
        {
            Login(user.Login);
            FirstName(user.FirstName);
            LastName(user.LastName);
            Password(user.Password);
            ConfirmPassword(user.ConfirmedPassword);
            IsElementLoaded();
            Register.Click();
        }

        public void IsPageDisplayed() => Driver.WaitUntilElementIsDisplay(_login);
        public void IsElementLoaded() => Driver.WaitUntilElementIsClickable(_register);


    }
}
