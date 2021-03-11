using System;
using Automation.UI.Foudation;
using Automation.UI.Foudation.Extenstions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.UI.IHS.Pages.Components
    {
    //since this is a shared component in multiple pages I am creating a component that can be invoked from any page to apply DRY principle
    public class Options : BasePage
        {
        private By cntOptions;
        public Options(IWebDriver driver, WebDriverWait Wait) : base(driver, Wait)
            {
            //locating the options component - this locator is the same on all the pages that uses this component
            this.cntOptions = LocateElementByCSS("div.sidebar");
            }

        private By btnBack { get { return LocateElementByCSS($"{cntOptions.GetSelector()} button.btn-sidebar-toggle"); } }

        public Options ClickBackButton()
            {
            ClickElement(btnBack);
            WaitForElementNotToBeVisible(btnBack);
            return this;
            }

        public bool IsOptionsVisible() => IsElementVisible(btnBack);

        }
    }
