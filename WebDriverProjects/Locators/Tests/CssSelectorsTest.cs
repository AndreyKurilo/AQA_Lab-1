using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators.Tests;

public class CssSelectorsTest : TestBase
{
    [Test]
    public void CssSelector_ElementsCount_Test()
    {
        var elements_byClass_arrow = _webDriver.FindElements(By.CssSelector(".arrow")).Count;
        Assert.GreaterOrEqual(elements_byClass_arrow, 5);
    }
    
    [Test]
    public void CssSelector_Class_Test()
    {
        var elementByClassName_arrow = _webDriver.FindElement(By.CssSelector(".arrow")).Text;
        Assert.AreEqual("5", elementByClassName_arrow);
    }
    
    [Test]
    public void CssSelector_DivSpanCount_Test()
    {
        var countDivSpan = _webDriver.FindElements(By.CssSelector("div,span")).Count;
        Assert.GreaterOrEqual(countDivSpan, 29);
    }


}