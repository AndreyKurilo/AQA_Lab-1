using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObject.Wrappers;

namespace PageObject.Test;

public class WrappersTest : BaseTest
{
    [Test]
    public void CheckBox_Test()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

        CheckBox checkBox_1 = new CheckBox(Driver, By.XPath("//*[@id = 'checkboxes']/input[1]"));
        checkBox_1.Check();
        Thread.Sleep(2000);
        checkBox_1.Uncheck();
        Thread.Sleep(2000);
    }

    [Test]
    public void Table_Test()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");

        Table table = new Table(Driver, By.TagName("table"));
        IWebElement cell_1 = table.GetElementFromCell("Lorem", "Iuvaret0", "Diceret");
        IWebElement cell_2 = table.GetElementFromCell("Ipsum", "Apeirian7", "Amet");


        Assert.AreEqual("Phaedrum0", cell_1.Text.Normalize());
        Assert.AreEqual("Consequuntur7", cell_2.Text.Normalize());
    }

    [Test]
    public void Table_FindByNameTest()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");

        Table table = new Table(Driver, By.TagName("table"));

        var element = table.FindElementByText("Adipisci0");
        var elementText = element.Text.Normalize();
        
        Assert.AreEqual("Adipisci0", elementText);
    }

    [Test]
    public void SliderTest()
    {
        var minRange = 0.0;
        var middleRange = 2.5;
        var maxRange = 5.0;
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/horizontal_slider");
        Actions actions = new Actions(Driver);
        actions.MoveToElement(Driver.FindElement(By.TagName("input"))).Click().Perform();
        
        Slider slider = new Slider(Driver);
        
        slider.SliderMove(minRange);
        Assert.AreEqual("0.0", slider.SlidersRange.Text);
        
        slider.SliderMove(middleRange);
        Assert.AreEqual("2.5", slider.SlidersRange.Text);
        
        slider.SliderMove(maxRange);
        Assert.AreEqual("5.0", slider.SlidersRange.Text);
    }
}