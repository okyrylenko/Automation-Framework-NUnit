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
        private static IConfiguration config = null;

        public static IConfiguration Configuration
        {
            get
            {
                config = config ?? new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return config;
            }
        }

        public static Browser Browser
        {
            get
            {
                browser = browser != Browser.None ? browser :
                    (Browser)Enum.Parse(typeof(Browser), TestContext.Parameters["Browser"]);
                return browser;
            }
        }
        public static Enums.Environment Environment
        {
            get
            {
                env = env != Enums.Environment.None ? env :
                    (Enums.Environment)Enum.Parse(typeof(Enums.Environment), TestContext.Parameters["Environment"]);
                return env;
            }
        }
        public static Location Location
        {
            get
            {
                location = location != Location.None ? location :
                    (Location)Enum.Parse(typeof(Location), TestContext.Parameters["Location"]);
                return location;
            }
        }
        public static Platform Plaform
        {
            get
            {
                platform =  platform != Platform.None ? platform :
                    (Platform)Enum.Parse(typeof(Platform), TestContext.Parameters["Platform"]);
                return platform;
            }
        }
        public static string BaseUrl
        {
            get
            {
                return baseUrl ?? (Configuration.GetSection(Environment.ToString()) ??
                    throw new Exception("The environment is not set in runsettings file." +
                    "Please update your runsettings file"))["BaseUrl"];
                //var url = config[$"{Environment.ToString()}:BaseUrl"];
                //var url = config.GetSection(Environment.ToString()).GetChildren().Where(val => val.Key.Equals("BaseUrl")).First().Value;
            }
        }
    }
}
