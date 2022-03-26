using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HeatCalculator_Kermi.Tests;

public class HeatLossCalculator : TestBase
{

    [Test]
    public void HeatLossTest()
    {
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет теплопотерь дома')]")).Click();
        WaitSeconds(3);
        InputValueToField("country", "Белорусь");
        InputValueToField("city1", "Минск");
        SetParameterWithId("outdoor_t", "-22");
        SetParameterWithId("indoor_t", "22");
        _webDriver.FindElement(By.CssSelector("a.a_t_losses")).Click();
        new SelectElement(_webDriver.FindElement(By.CssSelector("a.a_t_losses"))).SelectByText("Теплопотери через стены");
        InputValueToField("facade", "С вентилируемой воздушной прослойкой");
        SetParameterWithId("walls_area", "100");
        InputValueToField("wall_mat_1", "Минеральная вата");
        SetParameterWithId("layer_thickness_1", "0,3");
        _webDriver.FindElement(By.Name("button")).Click();
        var heatLossesThrowWalls = Int32.Parse(_webDriver.FindElement(By.Id("wall_losses")).Text);
        Assert.AreEqual(heatLossesThrowWalls, 981);
    }
    
}