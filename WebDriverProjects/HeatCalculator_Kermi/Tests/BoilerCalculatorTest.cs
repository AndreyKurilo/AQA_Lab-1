using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HeatCalculator_Kermi.Tests;

public class BoilerCalculatorTest : TestBase
{
    [Test]
    public void PowerBoilerCalcilationTest() 
    {
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет котла отопления')]")).Click();
        InputValueToField("country", "Казахстан");
        InputValueToField("city3", "Астана");
        WaitSeconds(2);
        SetParameterWithId("outdoor_t", "-30");
        SetParameterWithId("indoor_t", "22");
        //InputOutdoorTemperature("outdoor_t", "-30");
        //InputIndoorTemperature("indoor_t", "22");
        InputValueToField("water_damage", "Да");
        //_webDriver.FindElement(By.Id("water_heat")).Click();
        InputValueToField("ventilation", "Да");
        InputValueToField("floors", "2");
        SetParameterWithId("room_height", "3.0");
        SetParameterWithId("room_lenght", "10");
        SetParameterWithId("room_width", "10");
        InputValueToField("ceiling", "Чердак");
        InputValueToField("floor", "Фундамент");
        InputValueToField("floors", "1");
        InputValueToField("wall_material", "Сруб из бревен Ø25 см");
        InputValueToField("window", "Двухкамерный стеклопакет 4-10-4-10-4");
        SetParameterWithId("wind_area", "30");
        InputValueToField("bas", "Нет");
        SubmitForm("button");

        Thread.Sleep(2000);
        var result = _webDriver.FindElement(By.Id("boiler")).GetAttribute("value");
        Assert.AreEqual("22", result);
    }
}