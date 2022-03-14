using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AnotherLaminate
    {
        private IWebDriver _wd;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            _wd = new ChromeDriver();
            baseURL = "https://www.google.com/";
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
        public void TheAnotherLaminateTest()
        {
            _wd.Navigate().GoToUrl("https://calc.by/building-calculators/laminate.html");
            _wd.FindElement(By.Id("ln_room_id")).Click();
            _wd.FindElement(By.Id("ln_room_id")).Clear();
            _wd.FindElement(By.Id("ln_room_id")).SendKeys("");
            _wd.FindElement(By.Id("ln_room_id")).Clear();
            _wd.FindElement(By.Id("ln_room_id")).SendKeys("500");
            _wd.FindElement(By.Id("wd_room_id")).Click();
            _wd.FindElement(By.Id("wd_room_id")).Clear();
            _wd.FindElement(By.Id("wd_room_id")).SendKeys("400");
            _wd.FindElement(By.Id("ln_lam_id")).Click();
            _wd.FindElement(By.Id("ln_lam_id")).Clear();
            _wd.FindElement(By.Id("ln_lam_id")).SendKeys("");
            _wd.FindElement(By.Id("ln_lam_id")).Clear();
            _wd.FindElement(By.Id("ln_lam_id")).SendKeys("2000");
            _wd.FindElement(By.Id("wd_lam_id")).Click();
            _wd.FindElement(By.Id("wd_lam_id")).Clear();
            _wd.FindElement(By.Id("wd_lam_id")).SendKeys("");
            _wd.FindElement(By.Id("wd_lam_id")).Clear();
            _wd.FindElement(By.Id("wd_lam_id")).SendKeys("200");
            _wd.FindElement(By.Id("n_packing")).Click();
            _wd.FindElement(By.Id("n_packing")).Clear();
            _wd.FindElement(By.Id("n_packing")).SendKeys("10");
            _wd.FindElement(By.Id("laying_method_laminate")).Click();
            new SelectElement(_wd.FindElement(By.Id("laying_method_laminate")))
                .SelectByText("с использованием отрезанного элемента");
            _wd.FindElement(By.Id("min_length_segment_id")).Click();
            _wd.FindElement(By.Id("min_length_segment_id")).Clear();
            _wd.FindElement(By.Id("min_length_segment_id")).SendKeys("100");
            _wd.FindElement(By.Id("indent_walls_id")).Click();
            _wd.FindElement(By.Id("indent_walls_id")).Clear();
            _wd.FindElement(By.Id("indent_walls_id")).SendKeys("10");
            _wd.FindElement(By.Id("direction-laminate-id1")).Click();
            _wd.FindElement(By.LinkText("Рассчитать")).Click();
            //IWebElement result = _wd.FindElement(By.PartialLinkText("Требуемое количество досок ламината:"));
            IWebElement result = _wd.FindElement(By.XPath("//div[2]/div/span"));

            /*var result =
                _wd.FindElement(
                    By.PartialLinkText("Требуемое количество досок ламината:"))
                    .Text;*/
            Assert.AreEqual("52", result.Text);
            _wd.Close();
        }
    }
}
