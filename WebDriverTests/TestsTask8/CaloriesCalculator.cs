using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    [TestFixture]
    public class CaloriesCalculator
    {
        private IWebDriver _webDriver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            _webDriver = new ChromeDriver();
            //baseURL = "https://www.google.com/";
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
        public void TheCaloriesCalculatorTest()
        {
            _webDriver.Navigate().GoToUrl("https://www.calc.ru/kalkulyator-kalorii.html");
            _webDriver.FindElement(By.Id("age")).Click();
            _webDriver.FindElement(By.Id("age")).Clear();
            _webDriver.FindElement(By.Id("age")).SendKeys("35");
            _webDriver.FindElement(By.XPath("//form[@id='main_form']/table/tbody/tr[2]/td[2]/label/span")).Click();
            _webDriver.FindElement(By.XPath("//form[@id='main_form']/table/tbody/tr[2]/td[2]/label[2]/span")).Click();
            _webDriver.FindElement(By.XPath("//form[@id='main_form']/table/tbody/tr[2]/td[2]/label/span")).Click();
            _webDriver.FindElement(By.Id("weight")).Click();
            _webDriver.FindElement(By.Id("weight")).Clear();
            _webDriver.FindElement(By.Id("weight")).SendKeys("85");
            _webDriver.FindElement(By.Id("sm")).Click();
            _webDriver.FindElement(By.Id("sm")).Clear();
            _webDriver.FindElement(By.Id("sm")).SendKeys("185");
            _webDriver.FindElement(By.Id("activity")).Click();
            new SelectElement(_webDriver.FindElement(By.Id("activity"))).SelectByText("5 раз в неделю");
            _webDriver.FindElement(By.Id("submit")).Click();
            
            /*var wait1 = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(2000));             
            var appearElement = wait1.Until(
                ExpectedConditions
                    .ElementIsVisible(By.XPath("//div[@id='notifies_subscription_info']/input")));
            if (appearElement != null)
            {
                _webDriver.FindElement(By.XPath("//div[@id='notifies_subscription_info']/input")).Click();
            //}*/
            
            _webDriver.FindElement(By.XPath("//div[@id='notifies_subscription_info']/input")).Click();


            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5000));
            var calculatedInfoElement = wait.Until(
                ExpectedConditions.ElementIsVisible(By.XPath("//tr[2]/td")));
            
            var result = calculatedInfoElement.Text;
            Assert.AreEqual("3028 ккал/день", result);
            _webDriver.Close();
        }
    }
}
