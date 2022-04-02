using NUnit.Framework;
using OpenQA.Selenium;

namespace HeatCalculator_Kermi.Tests;

public class ElectricityFloorCalculator : TestBase
{
    [Test]
    public void ElectroFloorTest() 
    {
        _webDriver.FindElement(By.XPath("//span[contains(.,'Расчет электрического теплого пола')]")).Click();
        WaitUntilIsClickable(By.Id("el_f_width"));
        SetParameterWithId("el_f_width", "6");
        SetParameterWithId("el_f_lenght", "10");
        InputValueToField("room_type", "Кухня или спальня");
        InputValueToField("heating_type", "Основное отопление");
        //SetParameterWithId("el_f_losses", "1000");
        _webDriver.FindElement(By.Id("el_f_losses")).Clear();
        _webDriver.FindElement(By.Id("el_f_losses")).SendKeys("1000");
        //_javaScriptExecutor.ExecuteScript("window.scrollTo(0,301.3333435058594)");

        /* // This metod works if manualy scrolling down window while execution
        WaitUntilIsClickable(By.Name("button"));
        _webDriver.FindElement(By.Name("button")).Click();
        */
        
        ClickByResultButtonUsingJavaScriptExecutor(By.XPath("//input[@name='button']"));

        WaitSeconds(2);
        var cabelPowerResult = _webDriver.FindElement(By.Id("floor_cable_power")).GetAttribute("value");
        var cabelPowerPerSquareMeter = _webDriver.FindElement((By.Id("spec_floor_cable_power"))).GetAttribute("value");
        Assert.Multiple(() =>
        {
            Assert.AreEqual(cabelPowerResult, "1050");
            Assert.AreEqual(cabelPowerPerSquareMeter, "18");
        });
    }
}