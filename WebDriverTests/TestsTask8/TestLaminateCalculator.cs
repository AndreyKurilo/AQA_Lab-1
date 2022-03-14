using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestLaminateCalculator
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheLaminateCalculatorTest()
        {
            driver.Navigate().GoToUrl("https://calc.by/building-calculators/laminate.html");
            driver.FindElement(By.Id("ln_room_id")).Click();
            driver.FindElement(By.XPath("//div[@id='t3-content']/div[3]/article/section/div[2]/div[2]/div/div")).Click();
            driver.FindElement(By.Id("wd_room_id")).Click();
            driver.FindElement(By.Id("ln_lam_id")).Click();
            driver.FindElement(By.Id("wd_lam_id")).Click();
            driver.FindElement(By.Id("n_packing")).Click();
            driver.FindElement(By.Id("laying_method_laminate")).Click();
            driver.FindElement(By.Id("min_length_segment_id")).Click();
            driver.FindElement(By.Id("indent_walls_id")).Click();
            driver.FindElement(By.Id("direction-laminate-id1")).Click();
            driver.FindElement(By.LinkText("Рассчитать")).Click();
            driver.Close();
            driver.Navigate().GoToUrl("https://www.google.com/maps/@41.3012945,69.2926578,11z");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
