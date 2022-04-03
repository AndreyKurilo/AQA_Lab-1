using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Test;

public class LoginTest : BaseTest
{
    [Test]
    public void LoginSuccessTest()
    {
        LoginPage loginPage = new LoginPage(WebDriver, true);
        loginPage.UserNameInput.SendKeys(Configurator.Username);
        loginPage.UserPasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
        
        // Передаем false потому что мы переходим на следующую страницу не по урлу, 
        // а потому что кликнули ссылку "логин" см. 1.36.00
        ProductsPage productsPage = new ProductsPage(Driver, false);
        
        Assert.AreEqual("products", productsPage.Title.Text.ToLower());
    }
}