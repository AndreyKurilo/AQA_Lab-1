using NUnit.Framework;
using PageObject.Pages;

namespace PageObject.Test;

public class MakeOrderBuyAllProductsTest : TestsAuthorizationFoundation
{
    [Test]
    public void ChooseAllProductsAndMakeOrderTest()
    {
        // Arrange
        var productsPage = new ProductsPage(Driver, false);
        
        // Act
        productsPage.AddAllInventoryItemsToCart();

    }

}