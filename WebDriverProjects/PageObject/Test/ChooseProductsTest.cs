using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Test;

public class ChooseProductsTest : BaseTest
{
    [Test]
    public void ChosenItemsCountTest()
    {
        LoginPage loginPage = new LoginPage(_webDriver, true);
        loginPage.UserNameInput.SendKeys(Configurator.Username);
        loginPage.UserPasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();

        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_BackPack.Click();
        var result = _webDriver.FindElement(By.Id("remove-sauce-labs-backpack")).Text;
        Assert.AreEqual("REMOVE", result);
    }
}