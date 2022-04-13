using System;
using System.Drawing;
using NUnit.Framework;
using Onliner.Services;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace Onliner.Tests;

public class TestBase
{
    protected static IWebDriver WebDriver;

    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService().WebDriver;

        if (Configurator.BrowserType == "chrome")
        {
            // Set scale to 80%
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("document.body.style.zoom='80%'");
        }
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

    protected void ClickButtonUsingJavaScriptExecutor(By locator)
    {
        var resultButton = Driver.FindElement(locator);
        var javaScriptExecutor = (IJavaScriptExecutor) Driver;
        javaScriptExecutor.ExecuteScript("arguments[0].click();", resultButton);
    }
}