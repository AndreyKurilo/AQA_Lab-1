using System.Threading;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Onliner.Tests;

[AllureNUnit]
public class ActionsTest : TestBase
{
    [Test]
    public void Test_Click()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/status_codes");
        Actions actions = new Actions(Driver);
        actions.MoveToElement(Driver.FindElement(By.LinkText("200"))).Click().Build().Perform();
        Thread.Sleep(2000);
        var expectedResult = "This page returned a 200 status code.";
        var actualResult = Driver.FindElement(By.TagName("p")).Text.Substring(0, 37);
        Assert.AreEqual(expectedResult, actualResult);
        
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/status_codes");
        actions = new Actions(Driver);
        IWebElement link200 = Driver.FindElement(By.LinkText("200"));
        actions.Click(link200).Build().Perform();
        Thread.Sleep(2000);
        actualResult = Driver.FindElement(By.TagName("p")).Text.Substring(0, 37);
        Assert.AreEqual(expectedResult, actualResult);
   
    }

    [Test]
    public void Test_Hover()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/hovers");
        
        Actions actions = new Actions(Driver);
        actions.MoveToElement(Driver.FindElement(By.CssSelector("div.figure"))).Build().Perform();
        
        Assert.IsTrue(Driver.FindElement(By.XPath("//h5[. = 'name: user1']")).Displayed);
    }

    [Test]
    public void Test_DragAndDrop()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");

        IWebElement boxA = Driver.FindElement(By.Id("column-a"));
        IWebElement boxB = Driver.FindElement(By.Id("column-b"));
        
        Actions actions = new Actions(Driver);
        actions.DragAndDrop(boxA, boxB).Build().Perform();
        
        Thread.Sleep(2000);
    }
}