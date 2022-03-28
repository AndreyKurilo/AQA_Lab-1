using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators;

public class Tests
{
    private IWebDriver _webDriver;
    [SetUp]
    public void Setup()
    {
        var BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var FullPathToFile = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}";
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}