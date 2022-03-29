using System;
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

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Вариант 1: через установку в папку Resources - правый клик по драйверу
        // ->Properties->Build action = Content; Copy to output directory = Copy always
        // Должно отобразиться в папке проекта bin (если не оттображается бин - сделать Build проекта)
        var BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        FullPathToFile = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}somehtml.html";
        var fullPathToBrowserDriver = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}";
        _webDriver = new ChromeDriver(fullPathToBrowserDriver);
        _webDriver.Navigate().GoToUrl(FullPathToFile);
    }

    [Test]
    public void IdLocatorTest_1()
    {
        //_webDriver.Navigate().GoToUrl(FullPathToFile);
        var elementById_1 = _webDriver.FindElement(By.Id("1")).Text;
        Assert.AreEqual(elementById_1, "Test");
    }

    [Test]
    public void IdLocatorTest_2()
    {
        var elementById_11 = _webDriver.FindElement(By.Id("11")).Text;
        Assert.AreEqual(elementById_11, "Task");
    }

    [Test]
    public void IdLocatorTest_3()
    {
        var elementById_123 = _webDriver.FindElement(By.Id("123")).Text;
        Assert.AreEqual(elementById_123, "Locator");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _webDriver.Quit();
    }


}