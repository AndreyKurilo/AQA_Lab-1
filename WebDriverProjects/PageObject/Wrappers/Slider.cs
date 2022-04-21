using System;
using System.Globalization;
using OpenQA.Selenium;

namespace PageObject.Wrappers;

public class Slider
{
    private IWebDriver _driver;
    private static readonly By sliderLocator = By.TagName("input");
    private static readonly By rangeLocator = By.Id("range");
    
    public Slider(IWebDriver driver)
    {
        _driver = driver;
    }

    public void SliderMove(double neccesaryRange)
    {
        var currentRange = float.Parse(SlidersRange.Text, CultureInfo.InvariantCulture);
        while (currentRange != neccesaryRange)
        {
            if (currentRange < neccesaryRange)
            {
                SliderField.SendKeys(Keys.Right);
            }
            else
            {
                SliderField.SendKeys(Keys.Left);
            }
            currentRange = float.Parse(SlidersRange.Text, CultureInfo.InvariantCulture);
        }
    }

    public IWebElement SliderField => _driver.FindElement(sliderLocator);
    public IWebElement SlidersRange => _driver.FindElement(rangeLocator);

    //public IWebElement SlidersRange => WaitService.WaitElementIsExists(rangeLoctor);
    
}