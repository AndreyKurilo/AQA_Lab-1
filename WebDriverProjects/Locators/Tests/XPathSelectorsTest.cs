using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators.Tests;

public class XPathSelectorsTest : TestBase
{
    [Test]
    public void XPathSelector_ElementsCount_Test()
    {
        var elements_byClass_arrow = _webDriver.FindElements(By.XPath("//*[contains(@class, 'arrow')]")).Count;
        Assert.GreaterOrEqual(elements_byClass_arrow, 5);
    }

        
    [Test]
    public void XPath_Title_1st_Test()
    {
        var title_1st = _webDriver.FindElement(By.XPath("//h1/span[1]")).Text;
        Assert.AreEqual("Title 1", title_1st);
    }
    
    [Test] // Find total div & span
    public void XPathSelector_DivSpanCount_Test()
    {
        var countDivSpan = _webDriver.FindElements(By.XPath("//div,span")).Count;
        Assert.GreaterOrEqual(countDivSpan, 29);
    }
    
    [Test] // Find total span's wrapted to div
    public void XPathSelector_SpanWrapptedInDivCount_Test()
    {
        var countDivSpan = _webDriver.FindElements(By.XPath("//div/span")).Count;
        Assert.GreaterOrEqual(countDivSpan, 13);
    }

    [Test]
    public void XPathSelector_ElementAttribute_Test()
    {
        var elements_byAttribute_ids = _webDriver.FindElement(By.XPath("//*[contains(@ids, '1')]")).Text;
        Assert.AreEqual("Test", elements_byAttribute_ids);
    }

    [Test]
    public void CssSelector_ElementAttributeValueInDiv_Test()
    {
        var elements_byAttributeValueInDiv = _webDriver.FindElement(By.XPath("//*[contains(value='234')]")).Text;
        Assert.AreEqual("Test Title", elements_byAttributeValueInDiv);
    }
}