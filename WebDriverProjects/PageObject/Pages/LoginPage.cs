using System;
using OpenQA.Selenium;

namespace PageObject.Pages;

public class LoginPage : BasePage
{
    private const string END_POINT = "https://www.saucedemo.com";
    
    // Description of locators
    private static readonly By UsernameInputLocator = By.Id("user-name");
    private static readonly By PasswordInputLocator = By.Id("password");
    private static readonly By LoginButtonLocator = By.Id("login-button");

    // Constructors
    public LoginPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    // Атомарные методы
    public IWebElement UserNameInput => Driver.FindElement(UsernameInputLocator);
    public IWebElement UserPasswordInput => Driver.FindElement(PasswordInputLocator);
    public IWebElement LoginButton => Driver.FindElement(LoginButtonLocator);

}