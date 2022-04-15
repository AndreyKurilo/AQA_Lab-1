using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Onliner.Tests;

public class JS_Test : TestBase
{
    // Set and Get value
    [Test]
    public void Test_JS_actions_SetGetValues()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");

        IJavaScriptExecutor js_executor = (IJavaScriptExecutor) Driver;

        var inputField = Driver.FindElement(By.TagName("input"));
        var value = 10;
        
        js_executor.ExecuteScript("arguments[0].setAttribute('value', '" + value +"')", inputField);
        
        // в следующей строке мы берем значение из этого поля - это делается в случае, когда .Text не срабатывает -
        // возвращает пустую строку
        var actualValue = js_executor.ExecuteScript("return arguments[0].value", inputField);
        Thread.Sleep(2000);

        Assert.AreEqual(value, int.Parse(inputField.GetAttribute("value")));
        Assert.AreEqual(value, int.Parse(actualValue.ToString()));
    }
    
    // Scroll
    [Test]
    public void Test_JS_Actions_ScrollDown()
    {
        IJavaScriptExecutor js_executor = (IJavaScriptExecutor)Driver;
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/large");
        
        js_executor.ExecuteScript("window.scrollBy(0,250)");
        Thread.Sleep(2000);
        js_executor.ExecuteScript("window.scrollBy(0,250)");
        Thread.Sleep(2000);
        js_executor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        Thread.Sleep(2000);

        var element = Driver.FindElement(By.Id("no-siblings"));
        js_executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        Thread.Sleep(2000);
    }

    // Get Title
    [Test]
    public void Test_JS_Actions_GetTitle()
    {
        IJavaScriptExecutor js_executor = (IJavaScriptExecutor)Driver;
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        
        string title = js_executor.ExecuteScript("return document.title").ToString();
        Assert.AreEqual("The Internet", title);
    }

    // Get Title
    [Test]
    public void Test_JS_Actions_Back_Next_Pages()
    {
        IJavaScriptExecutor js_executor = (IJavaScriptExecutor)Driver;
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        Driver.FindElement(By.LinkText("Checkboxes")).Click();
        Thread.Sleep(2000);
        js_executor.ExecuteScript("window.history.go(1)");
        Assert.AreEqual("Checkboxes", Driver.FindElement(By.TagName("h3")).Text);
            
        js_executor.ExecuteScript("window.history.go(-1)");
        Thread.Sleep(2000);
        Assert.IsTrue(Driver.FindElement(By.LinkText("Checkboxes")).Displayed);

        js_executor.ExecuteScript("window.history.go(1)");
        Thread.Sleep(2000);
        Assert.AreEqual("Checkboxes", Driver.FindElement(By.TagName("h3")).Text);
    }
}