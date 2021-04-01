using OpenQA.Selenium;
using System;

namespace WPTest.Pages
{
    class BasePage
    {
        public IWebDriver Driver { get; }
        public string BaseUrl = "https://buggy.justtestit.org";

        protected BasePage(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }
    }
}
