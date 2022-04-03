using NUnit.Framework;
using PageObject.Services;

namespace PageObject.Test;

public class TestsAuthorizationFoundation : BaseTest
{
    [SetUp]
    public override void Setup()
    {
        base.Setup();
        Tools.Login(WebDriver);
    }
}