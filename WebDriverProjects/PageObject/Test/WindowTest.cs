using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Test;

public class WindowTest : BaseTest
{
    [Test]
    public void Test_NewWindowHandle()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/windows");

        string parentWindow = Driver.CurrentWindowHandle;
        
        Driver.FindElement(By.LinkText("Click Here")).Click();

        var windows = Driver.WindowHandles;
        foreach (var window in windows)
        {
            Console.Out.WriteLine("Switch to the window" + window);
            Driver.SwitchTo().Window(window);
        }
        
        Assert.AreEqual("New Window", Driver.FindElement(By.TagName("h3")).Text);
        
        Driver.Close();

        Driver.SwitchTo().Window(parentWindow);
        
        Assert.IsTrue(Driver.FindElement(By.LinkText("Click Here")).Displayed);
    }
}