using NUnit.Framework;
using PageObject.Pages;

namespace PageObject.Test;

public class LoginTest : BaseTest
{
    [Test]
    public void LoginSuccessTest()
    {
        LoginPage loginPage = new LoginPage(_webDriver, true);
        loginPage.UserNameInput.SendKeys("standard_user");
        loginPage.UserPasswordInput.SendKeys("secret_sauce");
        loginPage.LoginButton.Submit();
    }
}