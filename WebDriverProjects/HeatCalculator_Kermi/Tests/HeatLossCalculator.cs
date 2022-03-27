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
        WebDriverWait w = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет теплопотерь дома')]")).Click();
        //WaitSeconds(3);
        InputValueToField("country", "Белорусь");
        InputValueToField("city2", "Минск");
        //WaitSeconds(3);
        w.Until(ExpectedConditions.AlertState(false));
        SetParameterWithId("outdoor_t", "-22");
        //WaitSeconds(3);
        w.Until(ExpectedConditions.AlertState(false));
        SetParameterWithId("indoor_t", "22");
        _webDriver.FindElement(By.XPath("//h2[contains(.,'Теплопотери через стены')]")).Click();
        //new SelectElement(_webDriver.FindElement(By.CssSelector("a.a_t_losses"))).SelectByText("Теплопотери через стены");
        //_webDriver.FindElement(By.CssSelector(".change_im_h2")).Click();
        w.Until(ExpectedConditions.ElementIsVisible(By.Id("facade")));
        w.Until(ExpectedConditions.ElementToBeClickable(By.Id("facade")));
        //WaitSeconds(2);
        InputValueToField("facade", "С вентилируемой воздушной прослойкой");
        SetParameterWithId("walls_area", "100");
        InputValueToField("wall_mat_1", "Минеральная вата");
        SetParameterWithId("layer_thickness_1", "0.3");
        var resultButton = _webDriver.FindElement(By.XPath("//input[@name='button']"));
        var javaScriptExecutor = (IJavaScriptExecutor)_webDriver;
        javaScriptExecutor.ExecuteScript("arguments[0].click();", resultButton);
        var wallLossesInputField = _webDriver.FindElement(By.Id("wall_losses"));
        var heatLossesThrowWalls = wallLossesInputField.GetAttribute("text");
        Assert.AreEqual(heatLossesThrowWalls, "239");
    }
    
}