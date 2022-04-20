using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Wrappers;

public class Slider
{
    private IWebDriver _driver;
    private UIElement _uiElement;
    private static readonly By sliderLocator = By.TagName("input");
    private static readonly By rangeLocator = By.Id("range");


    public Slider(IWebDriver driver)
    {
        _uiElement = new UIElement(driver, sliderLocator);
    }

    public void SliderMove(double neccesaryRange)
    {
        var currentRange = Double.Parse(SlidersRange.Text);
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
            currentRange = Double.Parse(SlidersRange.Text);
        }
    }

    public IWebElement SliderField => _driver.FindElement(sliderLocator);
    public IWebElement SlidersRange => _driver.FindElement(rangeLocator);

    //public IWebElement SlidersRange => WaitService.WaitElementIsExists(rangeLoctor);
    
}