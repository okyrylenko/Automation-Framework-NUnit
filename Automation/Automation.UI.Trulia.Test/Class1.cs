using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Automation.UI.Foudation;

namespace Automation.UI.Trulia.Test
{
    public class Class1
    {

        [Test]
        public void Test()
        {
            var driver = new ChromeDriver(@"C:\Users\Alex\Desktop");
            driver.Navigate().GoToUrl($"https://www.{TestSettings.BaseUrl}.com");
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
