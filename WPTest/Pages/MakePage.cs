using OpenQA.Selenium;
using WPTest.Extensions;

namespace WPTest.Pages
{
    class MakePage : BasePage
    {
        public MakePage(IWebDriver driver) : base(driver)
        {

        }

        protected By _model = By.XPath("//a[normalize-space()='Model']");
        protected By _rank = By.XPath("//a[normalize-space()='Rank']");
        protected By _votes = By.XPath("//a[normalize-space()='Votes']");
        protected By _comments = By.XPath("//th[@class='comments']");

        public IWebElement Model => Driver.FindByWithWait(_model);
        public IWebElement Rank => Driver.FindElement(_rank);
        public IWebElement Votes => Driver.FindElement(_votes);
        public IWebElement Comments => Driver.FindElement(_comments);
    }
}
