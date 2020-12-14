using Automation.UI.Foudation.Enums;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace Automation.UI.Foudation    {
    public static class TestSettings
    {
        private static string baseUrl = null;
        private static Enums.Environment env;
        private static BrowserType browser;
        private static Location location;
        private static Platform platform;
        private static IConfiguration config = null;

        public static IConfiguration Configuration => config = config ??
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static BrowserType Browser => browser = browser != BrowserType.None ? browser :
                    (BrowserType)Enum.Parse(typeof(BrowserType), TestContext.Parameters["Browser"]);

        public static Enums.Environment Environment => env = env != Enums.Environment.None ? env :
                    (Enums.Environment)Enum.Parse(typeof(Enums.Environment), TestContext.Parameters["Environment"]);

        public static Location Location => location = location != Location.None ? location :
                    (Location)Enum.Parse(typeof(Location), TestContext.Parameters["Location"]);

        public static Platform Plaform => platform = platform != Platform.None ? platform :
                    (Platform)Enum.Parse(typeof(Platform), TestContext.Parameters["Platform"]);

        public static string BaseUrl => baseUrl ?? (Configuration.GetSection(Environment.ToString()) ??
                    throw new Exception("The environment is not set in runsettings file." +
                    "Please update your runsettings file"))["BaseUrl"];    }}
