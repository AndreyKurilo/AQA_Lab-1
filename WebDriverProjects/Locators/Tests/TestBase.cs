using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators.Tests;

public class TestBase
{
    protected IWebDriver _webDriver;
    protected string FullPathToFile;


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

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _webDriver.Quit();
    }
}