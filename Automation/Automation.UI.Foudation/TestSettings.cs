using Automation.UI.Foudation.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace Automation.UI.Foudation
{
    public static class TestSettings
    {
        private static string baseUrl = null;
        private static Enums.Environment env;
        private static Browser browser;
        private static Location location;
        private static Platform platform;

        public static Browser Browser
        {
            get
            {
                return browser != Browser.None ? browser :
                    (Browser)Enum.Parse(typeof(Browser), TestContext.Parameters["Browser"]);
            }
        }
        public static Enums.Environment Environment
        {
            get
            {
                return env != Enums.Environment.None ? env :
                    (Enums.Environment)Enum.Parse(typeof(Enums.Environment), TestContext.Parameters["Environment"]);
            }
        }
        public static Location Location
        {
            get
            {
                return location != Location.None ? location :
                    (Location)Enum.Parse(typeof(Location), TestContext.Parameters["Location"]);
            }
        }
        public static Platform Plaform
        {
            get
            {
                return platform != Platform.None ? platform :
                    (Platform)Enum.Parse(typeof(Platform), TestContext.Parameters["Platform"]);
            }
        }
        public static string BaseUrl
        {
            get
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json").Build();

                return baseUrl ?? (config.GetSection(Environment.ToString()) ??
                    throw new Exception("The environment is not set in runsettings file." +
                    "Please update your runsettings file"))["BaseUrl"];
                //var url = config[$"{Environment.ToString()}:BaseUrl"];
                //var url = config.GetSection(Environment.ToString()).GetChildren().Where(val => val.Key.Equals("BaseUrl")).First().Value;
            }
        }
    }
}
