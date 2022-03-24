using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace HeatCalculator_Kermi;

public class Tests
{
    private IWebDriver _webDriver;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Вариант 1: через установку в папку Resources - правый клик по драйверу
        // ->Properties->Build action = Content; Copy to output directory = Copy always
        // Должно отобразиться в папке проекта bin (если не оттображается бин - сделать Build проекта)
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var fullPathToBrowserDriver = $"{basePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}";
        
        _webDriver = new ChromeDriver(fullPathToBrowserDriver);
        //_webDriver = new FirefoxDriver(fullPathToBrowserDriver);
        
        // Вариант 2 - поставить Хромдрайвер через Нугет,
        // тогда _webDriver = new ChromeDriver() - пас не указывается;
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
        [TearDown]
        public void TearDown()
        {
            Console.Out.WriteLineAsync("TearDown after test metod");
        }
    
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.Out.WriteLineAsync("OneTimeTearDown finishes");
            _webDriver.Quit();
        }

    
}