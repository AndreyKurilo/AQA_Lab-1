using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Services;

namespace PageObject.Test;

public class BaseTest
{
    protected static IWebDriver _webDriver;

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
    
    public static IWebDriver Driver
    {
        get => _webDriver;
        set => _webDriver = value ?? throw new ArgumentNullException(nameof(value));
    }
}