using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Onliner.Services;

public class WaitService
{
    private IWebDriver _webDriver;
    private readonly WebDriverWait _wait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _webDriver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
        _fluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(Configurator.WaitTimeout),
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

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
        return _wait.Until(SeleniumExtras
            .WaitHelpers.ExpectedConditions
            .InvisibilityOfElementLocated(locator));
    }
    
    /*
    public bool WaitUntilElementInvisible(IWebElement webElement)
    {
        return _wait.Until(SeleniumExtras
            .WaitHelpers.ExpectedConditions
            .StalenessOf(webElement));
    }
*/
}