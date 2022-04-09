using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Onliner.Services;

public class WaitService
{
    private IWebDriver _webDriver;
    private readonly WebDriverWait _wait;
    private readonly WebDriverWait _explicitWait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _webDriver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
        _explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }

    public IWebElement WaitElementIsVisible(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitElementIsExists(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }

    public IWebElement WaitQuickElement(By locator)
    {
        return _fluentWait.Until(x => x.FindElement(locator));
    }

    public bool WaitUntilElementInvisible(By locator)
    {
        return _explicitWait.Until(SeleniumExtras
            .WaitHelpers.ExpectedConditions
            .InvisibilityOfElementLocated(locator));
    }
}