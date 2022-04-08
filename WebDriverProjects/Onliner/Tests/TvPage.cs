using System.Threading;
using NUnit.Framework;
using Onliner.Pages;
using OpenQA.Selenium;

namespace Onliner.Tests;

public class TvPage : TestBase
{

    [Test]
    public void Test_ChooseItemsAndGotoComparisonPage()
    {
        var numberItemsToCompare = 2;
        CatalogTVpage catalogTV = new CatalogTVpage(_webDriver, true);
        catalogTV.AddDefiniteNumberItemsToCompare(numberItemsToCompare);
        Thread.Sleep(1000);
        //catalogTV.ComparisonPageLink.Click();
        Assert.IsTrue(catalogTV.ComparisonPageLink.Displayed);
    }
}