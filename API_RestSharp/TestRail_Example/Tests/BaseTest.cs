using NLog;
using NUnit.Framework;
using TestRail.ApiTesting;
using TestRail_Example.Clients;
using TestRail_Example.Services;

namespace TestRail_Example.Tests;

public class BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService ProjectService = null!;
    protected MilestoneService MilestoneService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }
}