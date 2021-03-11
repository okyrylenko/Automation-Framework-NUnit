using System;
using Automation.UI.Foudation;
using Automation.UI.IHS.Pages.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.UI.IHS.Pages
    {
    public class HomePage : BasePage
        {
        IWebDriver driver;
        WebDriverWait wait;
        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
            {
            this.driver = driver;
            this.wait = wait;

            }

        public Options OptionsPane()
            {
            return new Options(this.driver, this.wait);
            }
        }
    }
