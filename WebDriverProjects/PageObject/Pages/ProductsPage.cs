using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string END_POINT = "/inventory.html";
    
    private static readonly By TitleBy = By.ClassName("title"); 

    public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
    
    public IWebElement Title => Driver.FindElement(TitleBy);
}