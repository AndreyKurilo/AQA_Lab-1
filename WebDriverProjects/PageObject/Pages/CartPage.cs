using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage
{
    private const string END_POINT = "/cart.html";
    private static readonly By TitleLocator = By.ClassName("title");


    public CartPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
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
    
    public ReadOnlyCollection<IWebElement> GetCartItems() =>
        Driver.FindElements(By.ClassName("inventory_item"));

    public ReadOnlyCollection<IWebElement> GetAddToCartButtons() =>
        Driver.FindElements(By.ClassName("btn_inventory"));

    public void AddAllInventoryItemsToCart()
    {
        foreach (var addToCartButton in GetAddToCartButtons())
            addToCartButton.Click();
    }

    
    public IWebElement Title => Driver.FindElement(TitleLocator);

}