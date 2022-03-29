using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators.Tests;

public class IdLocatorsTests : TestBase
{
    [Test]
    public void IdLocatorTest_1()
    {
        var elementById_1 = _webDriver.FindElement(By.Id("1")).Text;
        Assert.AreEqual("Test",elementById_1);
    }

    [Test]
    public void IdLocatorTest_2()
    {
        var elementById_11 = _webDriver.FindElement(By.Id("11")).Text;
        Assert.AreEqual("Task",elementById_11);
    }

    [Test]
    public void IdLocatorTest_3()
    {
        var elementById_123 = _webDriver.FindElement(By.Id("123")).Text;
        Assert.AreEqual("Locator",elementById_123);
    }
}