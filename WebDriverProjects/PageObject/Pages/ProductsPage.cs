using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string END_POINT = "/inventory.html";

    private static readonly By TitleLocator = By.ClassName("title");

    private static readonly By BackPack_AddLocator = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By BikeLight_AddLocator = By.Id("add-to-cart-sauce-labs-bike-light");
    private static readonly By BoltT_Shirt_AddLocator = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
    private static readonly By FleeceJacket_AddLocator = By.Id("add-to-cart-sauce-labs-fleece-jacket");
    private static readonly By Onesie_AddLocator = By.Id("add-to-cart-sauce-labs-onesie");
    private static readonly By Test_allTheThings_AddLocator = By.Id("add-to-cart-test.allthethings()-t-shirt-(red)");

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

    public ReadOnlyCollection<IWebElement> GetInventoryItems() =>
        Driver.FindElements(By.ClassName("inventory_item"));

    public ReadOnlyCollection<IWebElement> GetAddToCartButtons() =>
        Driver.FindElements(By.ClassName("btn_inventory"));

    public void AddAllInventoryItemsToCart()
    {
        foreach (var addToCartButton in GetAddToCartButtons())
            addToCartButton.Click();
    }

    public IWebElement Title => Driver.FindElement(TitleLocator);
    public IWebElement Item_BackPack => Driver.FindElement(BackPack_AddLocator);
    public IWebElement Item_BikeLight => Driver.FindElement(BikeLight_AddLocator);
    public IWebElement Item_BoltT_Shirt => Driver.FindElement(BoltT_Shirt_AddLocator);
    public IWebElement Item_FleeceJacket => Driver.FindElement(FleeceJacket_AddLocator);
    public IWebElement Item_Onesie => Driver.FindElement(Onesie_AddLocator);
    public IWebElement Item_Test_allTheThings => Driver.FindElement(Test_allTheThings_AddLocator);
}