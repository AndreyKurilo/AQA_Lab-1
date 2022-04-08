using NUnit.Framework;
using Onliner.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Onliner.Tests;

public class TestBase
{
    protected IWebDriver _webDriver;
    
    [SetUp]
    public void Setup()
    {
        _webDriver = new BrowserService().WebDriver;
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver.Quit();
    }

}