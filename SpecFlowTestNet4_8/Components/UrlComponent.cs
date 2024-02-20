using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SalesbookTest.Contracts;
using SalesbookTest.Drivers;
using SeleniumExtras.WaitHelpers;
using System;

namespace SalesbookTest.Components
{
    public class UrlComponent : IBaseComponent
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private By _linkLocator; 

        public UrlComponent(string linkLocator)
        {
            _driver = BrcWebdriver.GetInstance();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // Correctly initializing _linkLocator using the parameter
            _linkLocator = By.XPath($"//a[@href='{linkLocator}']");
        }

        
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void WaitForUrl(string url)
        {
            // Instantiate WebDriverWait with a 10-second timeout for this specific wait operation.
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the condition (URL contains the specified substring) is met.
                _wait.Until(driver => driver.Url.ToLower().Contains(url.ToLower()));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout reached waiting for URL to contain '{url}'. Current URL: {_driver.Url}");
                throw;
            }
        }


        public bool VerifyElementTextPresent(string expectedText)
        {
            try
            {
                // Use WebDriverWait to wait for the element with the expected text to be present in the DOM.
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[contains(text(), '{expectedText}')]")));

                // If the wait completes successfully, the element exists.
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                // If a timeout exception occurs, the element was not found within the specified time.
                return false;
            }
        }

        // Implementation of IBaseComponent's GetInstance method


        // Optionally, wait for the hyperlink to be clickable
        public void WaitUntilLinkClickable()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_linkLocator));
        }

        public IWebElement GetInstance()
        {
            return BrcWebdriver.GetInstance().FindElement(_linkLocator);
        }
        public IWebElement GetElement()
        {
            return GetInstance().FindElement(_linkLocator);
        }
    }
}
