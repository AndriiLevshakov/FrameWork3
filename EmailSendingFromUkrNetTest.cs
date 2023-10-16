using Core.Configuration;
using Core.DriverFactory;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EmailSendingFromUkrNetTest
    {
        IWebDriver driver;
        private UkrNetDesktopPage ukrNetDesktopPage;
        private UkrNetLoginPage ukrNetLoginPage;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            ukrNetLoginPage = new UkrNetLoginPage(driver);
            ukrNetDesktopPage = new UkrNetDesktopPage(driver);
            ukrNetLoginPage.NavigateToUkrNetLoginPage();            
        }

        [Test]
        public void SendEmailTest()
        {
            ukrNetLoginPage.LogIn();
            //Thread.Sleep(5000);
            ukrNetDesktopPage.SendEmail();

            Assert.IsTrue(ukrNetDesktopPage.ConfirmationCheck());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
