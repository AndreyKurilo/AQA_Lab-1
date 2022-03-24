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
    public class BoilerPower1
    {
        private IWebDriver _webDriver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            _webDriver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _webDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheBoilerPower1Test()
        {
            _webDriver.Navigate().GoToUrl("https://kermi-fko.ru/raschety.aspx");
            _webDriver.FindElement(By.XPath("//div[@id='ctl00_updatePanel']/table/tbody/tr[2]/td[2]/div[2]/table/tbody/tr[2]/td/div/a/div/span")).Click();
            _webDriver.Navigate().GoToUrl("https://kermi-fko.ru/raschety/raschet-kotla-otopleniya.aspx");
            _webDriver.FindElement(By.Id("country")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("country"))).SelectByText("Казахстан");
            _webDriver.FindElement(By.Id("city3")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("city3"))).SelectByText("Астана");
            _webDriver.FindElement(By.Id("outdoor_t")).Click();
            _webDriver.FindElement(By.Id("outdoor_t")).Click();
            _webDriver.FindElement(By.Id("outdoor_t")).Clear();
            _webDriver.FindElement(By.Id("outdoor_t")).SendKeys("-30");
            _webDriver.FindElement(By.Id("indoor_t")).Click();
            _webDriver.FindElement(By.Id("indoor_t")).Clear();
            _webDriver.FindElement(By.Id("indoor_t")).SendKeys("22");
            _webDriver.FindElement(By.Id("water_damage")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("water_damage"))).SelectByText("Да");
            _webDriver.FindElement(By.Id("water_heat")).Click();
            _webDriver.FindElement(By.Id("ventilation")).Click();
            _webDriver.FindElement(By.Id("floors")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("floors"))).SelectByText("2");
            _webDriver.FindElement(By.Id("room_height")).Click();
            _webDriver.FindElement(By.Id("room_height")).Clear();
            _webDriver.FindElement(By.Id("room_height")).SendKeys("3.0");
            _webDriver.FindElement(By.Id("room_lenght")).Click();
            _webDriver.FindElement(By.Id("room_lenght")).Clear();
            _webDriver.FindElement(By.Id("room_lenght")).SendKeys("10");
            _webDriver.FindElement(By.Id("room_width")).Click();
            _webDriver.FindElement(By.Id("room_width")).Clear();
            _webDriver.FindElement(By.Id("room_width")).SendKeys("10");
            _webDriver.FindElement(By.Id("ceiling")).Click();
            _webDriver.FindElement(By.Id("floor")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("floor"))).SelectByText("Фундамент");
            _webDriver.FindElement(By.Id("floors")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("floors"))).SelectByText("1");
            _webDriver.FindElement(By.Id("wall_material")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("wall_material"))).SelectByText("Сруб из бревен Ø25 см");
            _webDriver.FindElement(By.Id("window")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("window"))).SelectByText("Двухкамерный стеклопакет 4-10-4-10-4");
            _webDriver.FindElement(By.Id("wind_area")).Click();
            _webDriver.FindElement(By.Id("wind_area")).Clear();
            _webDriver.FindElement(By.Id("wind_area")).SendKeys("30");
            _webDriver.FindElement(By.Id("bas")).Click();
            _webDriver.FindElement(By.Name("button")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                _webDriver.FindElement(by);
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
                _webDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = _webDriver.SwitchTo().Alert();
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
