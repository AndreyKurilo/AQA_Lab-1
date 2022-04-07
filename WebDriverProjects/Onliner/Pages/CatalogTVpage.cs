using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Onliner.Pages;

public class CatalogTVpage
{
    private IWebDriver Driver;
    private const string END_POINT = "https://catalog.onliner.by/tv";

    // Описание локаторов
    //private static readonly By itemCheckBoxLocator = By.ClassName("schema-product__control");
    //private static readonly By itemCheckBoxLocator = By.CssSelector(".schema-product__group .schema-product div div div label.schema-product__control");
    private static readonly By itemCheckBoxLocator = By.XPath("//div[@id='schema-products']/div/div/div/div/div/label");


    /*
    private static readonly By comparisonPageLinkLocator = By.CssSelector("a[href*='compare']");
    private static readonly By comparisonPageLinkLocator = By.PartialLinkText("товара");
    private static readonly By comparisonPageLinkLocator = By.ClassName("compare-button__sub");
    
    private static readonly By comparisonPageLinkLocator = By.CssSelector(".compare-button__sub_main");
    */
    private static readonly By comparisonPageLinkLocator = By.CssSelector(".compare-button__sub_main");

    
    // Конструктор
    public CatalogTVpage(IWebDriver _webDriver)
    {
        Driver = _webDriver;
        Driver.Navigate().GoToUrl(END_POINT);
    }
    
    // Атомарные элементы
    public ReadOnlyCollection<IWebElement> GetItemsInTV_Page() =>
        Driver.FindElements(itemCheckBoxLocator);
    
    public void AddDefiniteNumberItemsToCompare(int numberToAdd)
    {
        
        for (int i = 0; i < numberToAdd; i++)
        {
            GetItemsInTV_Page()[i].Click();
        }
    
        /*
        foreach (var addToCompareButton in GetItemsInTV_Page())
            addToCompareButton.Click();
    */
    }

    public IWebElement ComparisonPageLink => Driver.FindElement(comparisonPageLinkLocator);
}