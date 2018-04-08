using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Lottoland.Helpers
{
    public static class DriverHelper
    {
        private static IWebDriver driver = null;

        public static IWebDriver InitializeDriver(string browserName)
        {
            if (driver != null)
                return driver;

            switch (browserName)
            {
                case "Firefox":
                case "FF":
                    FirefoxProfile ffProfile = new FirefoxProfile();
                    driver = new FirefoxDriver(ffProfile);

                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                default:
                    throw new Exception($"{browserName} browser is not supported by the framework.");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
                throw new Exception("Driver is not initialized.");
            return driver;
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public static void NavigateToPage(string pageUrl)
        {
            driver.Navigate().GoToUrl(pageUrl);
        }

        public static string GetPageUrl()
        {
            return driver.Url;
        }

        public static bool ElementExist(string xpath)
        {
            try
            {
                return driver.FindElement(By.XPath(xpath)) != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}