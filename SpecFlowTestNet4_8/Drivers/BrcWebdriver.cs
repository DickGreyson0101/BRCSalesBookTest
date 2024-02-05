using OpenQA.Selenium;
using SalesbookTest.SetUp;
using System.Configuration;

namespace SalesbookTest.Drivers
{
    public static class BrcWebdriver
    {
        public static IWebDriver driver;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                try
                {
                    driver = GetBrowser(ConfigurationManager.AppSettings["browserType"]);
                }
                catch (WebDriverException e)
                {
                    // Handle exceptions related to WebDriver initialization here
                    Console.WriteLine("WebDriver initialization failed: " + e.Message);
                    throw; // Re-throw the exception if necessary
                }
            }
            return driver;
        }

        public static IWebDriver GetBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    {
                        IBrowserFactory browserFactory = new ChromeBrowserFactory();
                        return browserFactory.CreateWebDriver();
                    }
                case "firefox":
                    {
                        IBrowserFactory browserFactory = new FirefoxBrowserFactory();
                        return browserFactory.CreateWebDriver();
                    }
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
        }
    }
}