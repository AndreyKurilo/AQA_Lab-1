using OpenQA.Selenium;

namespace PageObject.Pages;

public class YourInformationPage : BasePage
{
    public YourInformationPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        throw new System.NotImplementedException();
    }

    protected override bool IsPageOpened()
    {
        throw new System.NotImplementedException();
    }
}