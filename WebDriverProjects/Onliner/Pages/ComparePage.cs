using System;
using Onliner.Services;
using OpenQA.Selenium;

namespace Onliner.Pages;

public class ComparePage : PageBase
{
    private const string END_POINT = "/compare";
    private static readonly By TitleLocator = By.ClassName("b-offers-title");
    private static readonly By DiagonalTvFieldLocator = By.XPath("//span[contains(.,'Диагональ экрана')]");
    private static readonly By DiagonalTvTipLocator = By.XPath("//*[@id='product-table']/tbody[5]/tr[4]/td[1]/div/span");
    private static readonly By DiagonalTvTipTextLocator = By.XPath("//p[contains(.,'Размер диагонали экрана в дюймах.')]");

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
    
    public IWebElement Title => WaitService.WaitElementIsExists(TitleLocator);
    public IWebElement DiagonalTvField => WaitService.WaitElementIsExists(DiagonalTvFieldLocator);
    public IWebElement DiagonalTvTip => WaitService.WaitElementIsExists(DiagonalTvTipLocator);
    public IWebElement DiagonalTvTipText => WaitService.WaitElementIsVisible(DiagonalTvTipTextLocator);
    public bool IsTextTipWindowInvisible => WaitService.WaitUntilElementInvisible(DiagonalTvTipTextLocator);
}