using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    
    public class Class1
    {
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait;

        [Test]
        public void Test()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");
            Thread.Sleep(5000);
            driver.SwitchTo().Frame("myFrame");
            IWebElement inputField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='input_98']")));
            inputField.Click();
            inputField.SendKeys("98987");

            driver.Quit();

        }
        



    }
}
