using OpenQA.Selenium;

namespace PageObject.Pages;

public class LoginPage
{
    private static readonly By UsernameInputBy = By.Id("user-name");

    public LoginPage(IWebDriver _webDriver)
    {
        Driver = _webDriver;
    }

    public IWebDriver Driver { get; set; }
}