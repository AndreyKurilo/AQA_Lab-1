using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using Onliner.Services;
using OpenQA.Selenium;

namespace Onliner.Pages;

public class CatalogTVpage : PageBase
{
    private const string END_POINT = "/tv";
    private const int ITEMS_ON_PAGE = 30;
    
    // Описание локаторов
    private static readonly By itemCheckBoxLocator = By.XPath("//div[@id='schema-products']/div/div/div/div/div/label");
    private static readonly By comparisonPageLinkLocator = By.CssSelector(".compare-button__sub.compare-button__sub_main");
    
    // Конструктор
    public CatalogTVpage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
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
            return GetItemsOnTV_Page().Count == ITEMS_ON_PAGE;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    // Атомарные элементы
    public ReadOnlyCollection<IWebElement> GetItemsOnTV_Page() =>
        Driver.FindElements(itemCheckBoxLocator);
    
    public void AddDefiniteNumberItemsToCompare(int numberToAdd)
    {
        for (int i = 0; i < numberToAdd; i++)
        {
            GetItemsOnTV_Page()[i].Click();
        }
    }
    
    //public IWebElement ComparisonPageLink => Driver.FindElement(comparisonPageLinkLocator);
    public IWebElement ComparisonPageLink => WaitService.WaitElementIsExists(comparisonPageLinkLocator);
}