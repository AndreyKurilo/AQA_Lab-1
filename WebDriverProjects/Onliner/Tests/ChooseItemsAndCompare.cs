using System.Threading;
using NUnit.Framework;
using Onliner.Pages;
using OpenQA.Selenium.Interactions;

namespace Onliner.Tests;

public class ChooseItemsAndCompare : TestBase
{
    
    [Test]
    public void Test_ChooseItemsAndGotoComparisonPage()
    {
        var numberItemsToCompare = 2;
        var numberItemsToRemoveFromComparison = 1;
        CatalogTVpage catalogTV = new CatalogTVpage(Driver, true);

        catalogTV.AddDefiniteNumberItemsToCompare(numberItemsToCompare);
        Assert.IsTrue(catalogTV.ComparisonPageLink.Displayed);
        
        catalogTV.ComparisonPageLink.Click();
        ComparePage comparePage = new ComparePage(Driver, false);
        new Actions(Driver).MoveToElement(comparePage.DiagonalTvField).Click().Perform();
        comparePage.DiagonalTvTip.Click();
        Assert.IsTrue(comparePage.DiagonalTvTipText.Displayed); 
        comparePage.DiagonalTvTip.Click();
        Assert.IsTrue(comparePage.IsTextTipWindowInvisible);
        var chosenItemsCount = comparePage.GetItemsOnCompare_Page().Count;
        Assert.AreEqual(numberItemsToCompare, chosenItemsCount);
        for (int i = 0; i < numberItemsToRemoveFromComparison; i++)
        {
            comparePage.GetRemoveButtonsOnCompare_Page()[i].Click();
        }

        var itemsAfterRemove = comparePage.GetItemsOnCompare_Page().Count;
        Assert.AreEqual(numberItemsToCompare - numberItemsToRemoveFromComparison, itemsAfterRemove);

    }
}