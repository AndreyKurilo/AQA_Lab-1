using OpenQA.Selenium;

namespace PageObject.Wrappers;

public class Slider
{
    private UIElement _uiElement;
    
    public Slider(IWebDriver driver, By locator)
    {
        _uiElement = new UIElement(driver, locator);
    }

}