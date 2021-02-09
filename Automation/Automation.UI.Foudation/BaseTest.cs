using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Automation.UI.Foudation
    {
    public class BaseTest
        {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            this.Setdriver();
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            if (!TestContext.CurrentContext.Result.Outcome.Status.Equals(ResultState.Success))
                {
                //take screenshot, capture browser console errors, etc
                }
            driver.Quit();
        }

        private void Setdriver()
        {

            switch (TestSettings.Browser)
            {

                case Enums.BrowserType.Firefox:
                    driver = new FirefoxDriver(); //different FireFoxOptions can be inserted
                    driver.Manage().Window.Maximize();
                    break;
                //more browsers can be returned if needed
                default:
                    driver = new ChromeDriver(); //different ChromeOptions can be inserted
                    driver.Manage().Window.Maximize();
                    break;
            }

        }

    }
}