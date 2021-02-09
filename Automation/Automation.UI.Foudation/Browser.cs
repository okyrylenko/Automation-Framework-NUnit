using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Automation.UI.Foudation
{
    public class Browser
    {
        readonly IWebDriver driver;
        readonly WebDriverWait wait;

        public Browser(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        /// <summary>
        /// opens a url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T OpenUrl<T>(string url = "") where T : BasePage
        {
            driver.Navigate().GoToUrl($"{TestSettings.BaseUrl}/{url}");
            return (T)Activator.CreateInstance(typeof(T), this.driver, this.wait);
        }
    }
}
