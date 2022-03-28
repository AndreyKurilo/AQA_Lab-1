using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HeatCalculator_Kermi.Tests;

public class HeatLossCalculator : TestBase
{

    [Test]
    public void HeatLossTest()
    {
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет теплопотерь дома')]")).Click();
        InputValueToField("country", "Белорусь");
        InputValueToField("city2", "Минск");
        WaitUntilAlert(_webDriverWait);
        SetParameterWithId("outdoor_t", "-22");
        WaitUntilAlert(_webDriverWait);
        SetParameterWithId("indoor_t", "22");
        _webDriver.FindElement(By.XPath("//h2[contains(.,'Теплопотери через стены')]")).Click();
        WaitUntilIsVisible(By.Id("facade"));
        WaitUntilIsClickable(By.Id("facade"));
        InputValueToField("facade", "С вентилируемой воздушной прослойкой");
        SetParameterWithId("walls_area", "100");
        InputValueToField("wall_mat_1", "Минеральная вата");
        SetParameterWithId("layer_thickness_1", "0.3");
        ClickByResultButtonUsingJavaScriptExecutor(By.XPath("//input[@name='button']"));
        var wallLossesInputField = _webDriver.FindElement(By.Id("wall_losses"));
        var heatLossesThrowWalls = wallLossesInputField.GetAttribute("value");
        Assert.AreEqual(heatLossesThrowWalls, "981");
    }
}