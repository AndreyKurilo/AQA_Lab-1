using System.Threading;
using NUnit.Framework;
using Onliner.Pages;
using OpenQA.Selenium;

namespace Onliner.Tests;

public class FromCatalogTvPageToComparePageTest : TestBase
{

    [Test]
    public void Test_ChooseItemsAndGotoComparisonPage()
    {
        var numberItemsToCompare = 2;
        CatalogTVpage catalogTV = new CatalogTVpage(Driver, true);

        catalogTV.AddDefiniteNumberItemsToCompare(numberItemsToCompare);
        Assert.IsTrue(catalogTV.ComparisonPageLink.Displayed);
        
        catalogTV.ComparisonPageLink.Click();
        ComparePage comparePage = new ComparePage(Driver, false);

        Assert.AreEqual("Сравнение товаров", comparePage.Title.Text);
    
    }
}