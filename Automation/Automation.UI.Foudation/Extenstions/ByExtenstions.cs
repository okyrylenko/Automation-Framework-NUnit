using System;
using OpenQA.Selenium;

namespace Automation.UI.Foudation.Extenstions
    {
    public static class ByExtenstions
        {
        public static string GetSelector(this By by) => by.ToString().Split(": ")[1];
        }
    }
