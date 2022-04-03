using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;

namespace PageObject.Test;

[TestFixture]
public class ChosenGoodsTotalSum : BaseTest
{
    public int _totalSum;

    [Test]
    public void ChoseGoodItem()
    {
        //BasePage.Login();
        //*[@id="inventory_container"]/div/div[1]/div[2]/div[2]/div/text()[2]
        ProductsPage productsPage = new ProductsPage(Driver, false);

    }
}