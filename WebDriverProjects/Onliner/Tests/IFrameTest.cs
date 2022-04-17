using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Onliner.Tests;

[TestFixture]
[AllureNUnit]
public class IFrameTest : TestBase
{
    [Test]
    public void TestFrame()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/iframe");
        
        Assert.AreEqual(1, Driver.FindElements(By.TagName("iframe")).Count);

        // Способы переключения на фрейм
        
        // 1. по порядковому номеру
        //Driver.SwitchTo().Frame(0); 
        // 2. По id
        //Driver.SwitchTo().Frame("mce_0_ifr"); 
        // 3. по WebElement'у 
        Driver.SwitchTo().Frame(Driver.FindElement(By.TagName("iframe"))); 

        IWebElement pField = Driver.FindElement(By.TagName("p"));
        Assert.IsTrue(pField.Displayed);
    }
}