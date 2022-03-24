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
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var fullPathToBrowserDriver = $"{basePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}";
        
      /*  Console.WriteLine("Choose browser (Chrome default):");
        Console.WriteLine("1 - Chrome");
        Console.WriteLine("2 - FireFox");
        var browserDriwer =Int32.Parse(Console.ReadLine());
        switch (browserDriwer)
        {
            case 1:
                _webDriver = new ChromeDriver(fullPathToBrowserDriver);
                break;
            case 2:
                _webDriver = new FirefoxDriver(fullPathToBrowserDriver);
                break;
            default:
                _webDriver = new ChromeDriver(fullPathToBrowserDriver);
                break;
        }*/
        _webDriver = new ChromeDriver(fullPathToBrowserDriver);
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
            _webDriver.Close();
        }

    
}