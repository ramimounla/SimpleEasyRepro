using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;
using System.IO;

namespace SimpleEasyRepro
{
    [TestClass]
    public class EasyReproTest
    {
        [TestMethod]
        public void SimpleLogin()
        {
            var Options = new BrowserOptions
            {
                BrowserType = BrowserType.Chrome,
                PrivateMode = true,
                FireEvents = false,
                Headless = false,
                UserAgent = false,
                DefaultThinkTime = 2000,
                RemoteBrowserType = BrowserType.Chrome,
                RemoteHubServer = new Uri("http://1.1.1.1:4444/wd/hub"),
                UCITestMode = true,
                UCIPerformanceMode = true,
                DriversPath = Directory.GetCurrentDirectory()
            };

            var username = "@";
            var password = "";
            var xrmUri = new Uri("https://yourorganisation.crm.dynamics.com");

            var client = new WebClient(Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(xrmUri, username.ToSecureString(), password.ToSecureString());
                xrmApp.Navigation.OpenApp("Sales Hub");
                xrmApp.Navigation.OpenSubArea("Sales", "Accounts");
            }
        }
    }
}