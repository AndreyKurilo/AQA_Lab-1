using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HeatCalculator_Kermi.Tests;

public class TestBase
{
    protected IWebDriver _webDriver;

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

    [SetUp]
    public void Setup()
    {
    }

    protected void SubmitForm(string locatorByName)
    {
        _webDriver.FindElement(By.Name(locatorByName)).Click();
    }

    protected void SetParameterOf(string idToFind, string text)
    {
        _webDriver.FindElement(By.Id(idToFind)).Click();
        _webDriver.FindElement(By.Id(idToFind)).Clear();
        _webDriver.FindElement(By.Id(idToFind)).SendKeys(text);
    }

    protected void WaitSeconds(int sec)
    {
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
    }

    protected void InputValueToField(string idToFind, string inputText)
    {
        _webDriver.FindElement(By.Id(idToFind)).Click();
        new SelectElement(_webDriver.FindElement(By.Id(idToFind))).SelectByText(inputText);
    }

    private void InputIndoorTemperature(string idToFind, string text)
    {
        _webDriver.FindElement(By.Id(idToFind)).Click();
        _webDriver.FindElement(By.Id(idToFind)).Clear();
        _webDriver.FindElement(By.Id(idToFind)).SendKeys(text);
    }

    private void InputOutdoorTemperature(string idToFind, string text)
    {
        _webDriver.FindElement(By.Id(idToFind)).Click();
        _webDriver.FindElement(By.Id(idToFind)).Clear();
        _webDriver.FindElement(By.Id(idToFind)).SendKeys(text);
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