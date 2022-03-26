using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

        _webDriver.Navigate().GoToUrl("https://kermi-fko.ru/raschety.aspx");
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PowerBoilerCalcilationTest()
    {
        _webDriver
            .Navigate()
            .GoToUrl("https://kermi-fko.ru/raschety/raschet-kotla-otopleniya.aspx");
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет котла отопления')]")).Click();
        InputValueToField("country", "Казахстан");
        InputValueToField("city3", "Астана");
        WaitSeconds(2);
        InputOutdoorTemperature("outdoor_t", "-30");
        InputIndoorTemperature("indoor_t", "22");
        InputValueToField("water_damage", "Да");
       //_webDriver.FindElement(By.Id("water_heat")).Click();
       InputValueToField("ventilation", "Да");
        InputValueToField("floors", "2");
        _webDriver.FindElement(By.Id("room_height")).Click();
        _webDriver.FindElement(By.Id("room_height")).Clear();
        _webDriver.FindElement(By.Id("room_height")).SendKeys("3.0");
        _webDriver.FindElement(By.Id("room_lenght")).Click();
        _webDriver.FindElement(By.Id("room_lenght")).Clear();
        _webDriver.FindElement(By.Id("room_lenght")).SendKeys("10");
        _webDriver.FindElement(By.Id("room_width")).Click();
        _webDriver.FindElement(By.Id("room_width")).Clear();
        _webDriver.FindElement(By.Id("room_width")).SendKeys("10");
        _webDriver.FindElement(By.Id("ceiling")).Click();
        _webDriver.FindElement(By.Id("floor")).Click();
        new SelectElement(_webDriver.FindElement(By.Id("floor"))).SelectByText("Фундамент");
        _webDriver.FindElement(By.Id("floors")).Click();
        new SelectElement(_webDriver.FindElement(By.Id("floors"))).SelectByText("1");
        _webDriver.FindElement(By.Id("wall_material")).Click();
        new SelectElement(_webDriver.FindElement(By.Id("wall_material"))).SelectByText("Сруб из бревен Ø25 см");
        _webDriver.FindElement(By.Id("window")).Click();
        new SelectElement(_webDriver.FindElement(By.Id("window"))).SelectByText("Двухкамерный стеклопакет 4-10-4-10-4");
        _webDriver.FindElement(By.Id("wind_area")).Click();
        _webDriver.FindElement(By.Id("wind_area")).Clear();
        _webDriver.FindElement(By.Id("wind_area")).SendKeys("30");
        _webDriver.FindElement(By.Id("bas")).Click();
        _webDriver.FindElement(By.Name("button")).Click();

        Thread.Sleep(2000);
        var result = _webDriver.FindElement(By.Id("boiler")).GetAttribute("value");
        Assert.AreEqual("22", result);
    }

    private void WaitSeconds(int sec)
    {
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
    }

    private void InputValueToField(string idToFind, string inputText)
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