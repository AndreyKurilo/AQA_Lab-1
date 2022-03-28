using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

public class Tests
{
    private IWebDriver _webDriver;
    private string FullPathToFile;

    [SetUp]
    public void Setup()
    {
        var BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        FullPathToFile = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}somehtml.html";
        var fullPathToBrowserDriver = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}";
        _webDriver = new ChromeDriver(fullPathToBrowserDriver);
    }

    [Test]
    public void Test1()
    {
        _webDriver.Navigate().GoToUrl(FullPathToFile);
        var element = _webDriver.FindElement(By.Id("1"));
        Assert.NotNull(element);
    }
}