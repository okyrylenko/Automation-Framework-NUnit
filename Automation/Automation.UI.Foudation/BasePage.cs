using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation.UI.Foudation
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }


        /// <summary>
        /// locate element by css
        /// </summary>
        /// <param name="css"></param>
        /// <returns></returns>
        public By LocateElementByCSS(string css) => By.CssSelector(css);


        /// <summary>
        /// find element 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public IWebElement FindElement(By by) => this.driver.FindElement(by);

        /// <summary>
        /// clicks on the element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public BasePage ClickElement(By locator)
        {
            FindElement(locator).Click();
            return this;
        }

        /// <summary>
        /// waits for element to be visible
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public BasePage WaitForElementNotToBeVisible(By locator)
        {
            this.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            return this;
        }


        /// <summary>
        /// checking if element visible on the screen or not
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool IsElementVisible(By locator)
        {
            return this.FindElement(locator).Displayed;
        }
    }


}
