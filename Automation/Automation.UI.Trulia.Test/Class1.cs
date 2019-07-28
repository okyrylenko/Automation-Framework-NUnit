using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Automation.UI.Trulia.Test
{
    public class Class1
    {

        [Test]
        public void Test()
        {
            var env = TestContext.Parameters["Environment"];

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true,true).Build();

            var v = config.GetSection(env)["BaseUrl"];
            var v1 = config[$"{env}:BaseUrl"];
            var url = config.GetSection(env).GetChildren().Where(val => val.Key.Equals("BaseUrl")).First().Value;

            var driver = new ChromeDriver(@"C:\Users\Alex\Desktop");
            driver.Navigate().GoToUrl($"https://www.{url}.com");
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
