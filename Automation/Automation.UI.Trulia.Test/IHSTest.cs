using Automation.UI.IHS.Pages;
using NUnit.Framework;

using Automation.UI.Foudation;

namespace Automation.UI.Trulia.Test    {
    [TestFixture]
    public class IHSTest : BaseTest        {
        [Test]
        public void Test()            {

            Assert.False(new Browser(driver, wait)
                .OpenUrl<HomePage>()
                .OptionsPane()
                .ClickBackButton()
                .IsOptionsVisible());            }        }    }
