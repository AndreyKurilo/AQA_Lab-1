using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Onliner.Pages;

public class CatalogTVpage : PageBase
{
    private const string END_POINT = "https://catalog.onliner.by/tv";
    private const int ITEMS_ON_PAGE = 30;
    
    // Описание локаторов
    private static readonly By itemCheckBoxLocator = By.XPath("//div[@id='schema-products']/div/div/div/div/div/label");
    private static readonly By comparisonPageLinkLocator = By.CssSelector(".compare-button__sub_main");
    
    // Конструктор
    public CatalogTVpage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }
    // Old constructor
    /*
    public CatalogTVpage(IWebDriver _webDriver)
    {
        Driver = _webDriver;
        Driver.Navigate().GoToUrl(END_POINT);
    }
    */
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(END_POINT);
    }

    protected override bool IsPageOpened()
    {
        if(GetItemsOnTV_Page().Count == ITEMS_ON_PAGE) return true;
        return false;
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

    public IWebElement ComparisonPageLink => Driver.FindElement(comparisonPageLinkLocator);
}