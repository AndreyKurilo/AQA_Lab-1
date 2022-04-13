using System;
using System.Threading;
using NUnit.Framework;
using Onliner.Pages;
using Onliner.Services;
using OpenQA.Selenium;

namespace Onliner.Tests;

public class MultiWindows_Test : TestBase
{
    [Test]
    public void Test_MultipleWindow()
    {
        var waitService = new WaitService(Driver);
        CatalogTVpage catalogTV = new CatalogTVpage(Driver, true);
        string parentWindow = Driver.CurrentWindowHandle;
        ClickButtonUsingJavaScriptExecutor(CatalogTVpage.vKontakteButtonLocator);
        ClickButtonUsingJavaScriptExecutor(CatalogTVpage.facebookButtonLocator);
        //catalogTV.VK_link.Click(); так работает под Хромом
        //catalogTV.FB_link.Click();
        var windowsOpen = Driver.WindowHandles;
        Assert.AreEqual(3, windowsOpen.Count);
       
        Console.WriteLine("Switch to " + windowsOpen[1]);
        Driver.SwitchTo().Window(windowsOpen[1]);
        Assert.AreEqual(parentWindow, windowsOpen[0]);
        var buttonVK = By.CssSelector("button.quick_reg_button.flat_button.button_wide");
        Assert.IsTrue(waitService.WaitElementIsExists(buttonVK).Displayed);
        //Assert.IsTrue(Driver.FindElement(By.Id("l_aud")).Displayed); //*[@id="l_aud"]/a/span[1]
        //Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='l_aud']/a/span[1]")).Displayed);
        //Assert.IsTrue(Driver.FindElement(By.CssSelector("span.left_label.inl_bl")).Displayed);
        //Assert.IsTrue(Driver.FindElement(By.ClassName("left_label.inl_bl")).Displayed);

        Console.WriteLine("Switch to " + windowsOpen[2]);
        Driver.SwitchTo().Window(windowsOpen[2]);
        var buttonFB = By.CssSelector(".bp9cbjyn.j83agx80.hzruof5a");
        Assert.IsTrue(waitService.WaitElementIsExists(buttonFB).Displayed);

        Driver.SwitchTo().Window(parentWindow);
        Assert.IsTrue(catalogTV.LogoOnliner.Displayed);
        
        Driver.Quit();
        Assert.Pass();
    }
}