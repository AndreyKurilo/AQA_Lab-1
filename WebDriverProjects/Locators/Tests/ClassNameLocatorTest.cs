using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators.Tests;

[AllureNUnit]
public class ClassNameLocatorTest : TestBase
{
    [Test]
    public void ClassNameLocator_arrow_Test()
    {
        var elementByClassName_arrow = _webDriver.FindElement(By.ClassName("arrow")).Text;
        Assert.AreEqual("5", elementByClassName_arrow);
    }
}