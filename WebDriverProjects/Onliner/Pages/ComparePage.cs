using System;
using Onliner.Services;
using OpenQA.Selenium;

namespace Onliner.Pages;

public class ComparePage : PageBase
{
    private const string END_POINT = "/compare";
    private static readonly By TitleLocator = By.ClassName("b-offers-title");

    public ComparePage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
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
}