using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Test;

public class ChooseProductsFoundation : TestsAuthorizationFoundation
{
    [Test]
    public void ChosenItemsCountTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_BackPack.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-backpack")).Text;
        Assert.AreEqual("REMOVE", result);
    }
}