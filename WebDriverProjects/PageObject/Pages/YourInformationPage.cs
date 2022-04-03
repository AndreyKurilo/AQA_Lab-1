using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class YourInformationPage : BasePage
{
    private const string END_POINT = "/checkout-step-one.html";

    private static readonly By TitleLocator = By.ClassName("title");

    public YourInformationPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public IWebElement Title => Driver.FindElement(TitleLocator);

    public void FillUsersData()
    {
        Driver.FindElement(By.Id("first-name")).SendKeys(Configurator.FirstName);
        Driver.FindElement(By.Id("last-name")).SendKeys(Configurator.LastName);
        Driver.FindElement(By.Id("postal-code")).SendKeys(Configurator.PostalCode);
    }
}