﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Threading;

namespace WPTest.Extensions
{
    public static class WebElementExtensions
    {
        public static bool Debug = false;

        public static void ClearByHotkeys(this IWebElement webElement)
        {
            var driver = webElement.getDriverFromWebElement();
            var actions = new Actions(driver);

            webElement.DoubleClick();
            Thread.Sleep(100);

            actions.KeyDown(Keys.Control);
            actions.SendKeys("a");
            actions.KeyUp(Keys.Control);
            actions.SendKeys(Keys.Backspace);
            actions.Build().Perform();
        }


        public static void HighlightElement(this IWebElement webElement, int Duration = 3)
        {
            IJavaScriptExecutor JSDriver;
            var driver = getDriverFromWebElement(webElement);
            JSDriver = (IJavaScriptExecutor)driver;
            string OriginalStyle = webElement.GetAttribute("style");
            JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
            webElement,
           "style",
           "border: 2px solid red; border-style: dashed;");
            Thread.Sleep(Duration * 500);
            JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
            webElement,
           "style",
           OriginalStyle);
        }

        public static void SendText(this IWebElement webElement, string value)
        {
            if (Debug) webElement.HighlightElement(1);
            webElement.SendKeys(value);
        }

        //public static void FindElement(this IWebElement webElement, By by)
        //{
        //    webElement.FindElement(by);
        //}

        public static void HoverElement(this IWebElement webElement)
        {
            try
            {
                var actionBuilder = new Actions(getDriverFromWebElement(webElement));
                actionBuilder.MoveToElement(webElement).Build().Perform();
            }
            catch (StaleElementReferenceException staleElementReferenceException)
            {
                CustomTestContext.WriteLine(
                    "StaleElementReferenceException: HoverElement.", staleElementReferenceException);
                var actionBuilder = new Actions(getDriverFromWebElement(webElement));
                actionBuilder.MoveToElement(webElement).Build().Perform();
            }
        }

        public static void DoubleClickElementAtPoint(this IWebElement webElement, int x, int y)
        {
            var actionBuilder = new Actions(getDriverFromWebElement(webElement));
            actionBuilder
                .MoveToElement(webElement, x, y)
                .DoubleClick()
                .Build()
                .Perform();
        }

        public static void Scroll(this IWebElement webElement)
        {
            try
            {
                webElement.scrollToWebElement();
            }
            catch (StaleElementReferenceException staleElementReferenceException)
            {
                CustomTestContext.WriteLine(
                    "StaleElementReferenceException: Scroll: " + webElement.TagName, staleElementReferenceException);
                webElement.scrollToWebElement();
            }
        }

        public static void DoubleClick(this IWebElement webElement)
        {
            var driver = getDriverFromWebElement(webElement);

            try
            {
                var action = new Actions(driver);
                action.DoubleClick(webElement);
                action.Perform();
            }
            catch (StaleElementReferenceException staleElementReferenceException)
            {
                CustomTestContext.WriteLine(
                    "StaleElementReferenceException: DoubleClickElement: "
                    + webElement.TagName, staleElementReferenceException);
                var action = new Actions(driver);
                action.DoubleClick(webElement);
                action.Perform();
            }
        }

        private static void scrollToWebElement(this IWebElement webElement)
        {
            var driver = getDriverFromWebElement(webElement);

            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(
                    "arguments[0].scrollIntoView(true); window.scrollBy(0,-200);", webElement);
            }
            catch (StaleElementReferenceException)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(
                    "arguments[0].scrollIntoView(true); window.scrollBy(0,-200);", webElement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ScrollDown(this IWebElement webElement)
        {
            var driver = getDriverFromWebElement(webElement);

            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(
                    "arguments[0].scrollIntoView(true); window.scrollBy(0, 100);", webElement);
            }
            catch (StaleElementReferenceException)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); window.scrollBy(0, 100);", webElement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static IWebDriver getDriverFromWebElement(this IWebElement webElement)
        {
            IWebDriver wrappedDriver;

            try
            {
                wrappedDriver = ((IWrapsDriver)webElement).WrappedDriver;
            }
            catch (InvalidCastException)
            {
                var wrappedElement = ((IWrapsElement)webElement).WrappedElement;
                wrappedDriver = ((IWrapsDriver)wrappedElement).WrappedDriver;
            }

            return wrappedDriver;
        }
    }

}
