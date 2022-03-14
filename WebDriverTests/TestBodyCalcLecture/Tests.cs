using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _wd;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            _wd = new ChromeDriver();
            //baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _wd.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TestBodyCalculator()
        {
            //string? result;
            _wd.Navigate().GoToUrl("https://calc.by/weight-and-calories/body-mass-index-calculator.html");
            _wd.FindElement(By.Id("bmiVar1")).Click();
            _wd.FindElement(By.Id("bmiVar1")).Clear();
            _wd.FindElement(By.Id("bmiVar1")).SendKeys("192");
            _wd.FindElement(By.Id("bmiVar2")).Click();
            _wd.FindElement(By.Id("bmiVar2")).Clear();
            _wd.FindElement(By.Id("bmiVar2")).SendKeys("103");
            _wd.FindElement(By.XPath("//div[@id='t3-content']/div[3]/article/section/div[2]/div[2]/div/span")).Click();
            var result = _wd.FindElement(By.Id("AnswerBMI1")).Text;
            Assert.AreEqual("Избыточной массе тела (предожирение)", result);
            _wd.Close();
        }
    }
}