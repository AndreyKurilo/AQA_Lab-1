using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HeatCalculator_Kermi.Tests;

public class HeatLossCalculator
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

        _webDriver.Navigate().GoToUrl("https://kermi-fko.ru/raschety.aspx");
    }

    [Test]
    public void HeatLossTest()
    {
        _webDriver.FindElement(By.CssSelector(".hv .calc_m_span")).Click();

    }
    
    public void OneTimeTearDown()
    {
        Console.Out.WriteLineAsync("OneTimeTearDown finishes");
        _webDriver.Quit();
    }

}