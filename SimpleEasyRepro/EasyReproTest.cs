using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

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
                PrivateMode = true
            };

            var username = "@.onmicrosoft.com";
            var password = "";
            var xrmUri = new Uri("https://.crm.dynamics.com");

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