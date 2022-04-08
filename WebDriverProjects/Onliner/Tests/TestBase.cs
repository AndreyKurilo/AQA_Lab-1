using System;
using NUnit.Framework;
using Onliner.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Onliner.Tests;

public class TestBase
{
    protected static IWebDriver WebDriver;
    
    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService().WebDriver;
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
    
    public static IWebDriver Driver
    {
        get => WebDriver;
        set => WebDriver = value ?? throw new ArgumentNullException(nameof(value));
    }
}