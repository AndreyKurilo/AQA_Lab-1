using System.Diagnostics;
using System.Net;
using NLog;
using NUnit.Framework;
using TestRail.ApiTesting;
using TestRail_Example.Tests.Databases;
using TestRail_Example.Tests.Models;
using TestRail_Example.Tests.Services;

namespace TestRail_Example.Tests;

public class MilestoneDataFromPostgresTest : BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project = null!;
    private Milestone? _milestone;
    private SimpleDBConnector _simpleDbConnector = null!;
    private MilestoneTestDataService _milestoneTestDataService = null!;
    private MilestoneTestData? _milestoneTestDataForAddAndUpdate;
    private MilestoneTestData? _milestoneTestDataForGet;

    [SetUp]
    public void SetUp()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _milestoneTestDataService = new MilestoneTestDataService(_simpleDbConnector.Connection);

        _milestoneTestDataForAddAndUpdate = _milestoneTestDataService.GetDataForAddAndUpdate()[0];
        _milestoneTestDataForGet = _milestoneTestDataService.GetDataForGet()[0];
    }

    [TearDown]
    public void TearDown() => _simpleDbConnector.CloseConnection();

    [Test]
    [Order(1)]
    public void AddProjectTest()
    {
        _project = new Project
        {
            Name = "AK Test 1",
            Announcement = "Some description!!!",
            ShowAnnouncement = true,
            SuiteMode = 1
        };

        var actualProject = ProjectService.AddProject(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
    }

    [Test]
    [Order(2)]
    public void AddMilestoneTest()
    {
        _milestone = new Milestone()
        {
            ProjectId = _project.Id,
            Name = _milestoneTestDataForAddAndUpdate!.Name,
            Description = _milestoneTestDataForAddAndUpdate!.Description
        };

        var actualMilestone = MilestoneService.AddMilestone(_milestone);
        _milestone = actualMilestone.Result;
        _logger.Info(_milestone.ToString());
    }


    [Test]
    [Order(3)]
    public void GetMilestoneTest()
    {
        _logger.Info(MilestoneService.GetMilestone(_project.Id.ToString()).Result.ToString());
        Assert.AreEqual("AK Milestone Test 1", _milestone!.Name);
    }

    [Test]
    [Order(4)]
    public void GetMilestonesTest()
    {
        _milestone = new Milestone()
        {
            ProjectId = _project.Id,
            Name = _milestoneTestDataForGet!.Name, //"AK Milestone Test 2",
            Description = _milestoneTestDataForGet.Description //"AK description for milestone 2",
        };

        var actualMilestone = MilestoneService.AddMilestone(_milestone);
        _milestone = actualMilestone.Result;

        var milestones = MilestoneService.GetMilestones(_project.Id).Result;
        _logger.Info(milestones.Size);
        foreach (var milestone in milestones.MilestonesList)
        {
            _logger.Info(milestone.ToString);
        }

        Assert.AreEqual(2, milestones.Size);
    }

    [Test]
    [Order(5)]
    public void UpdateAddMilestoneTest()
    {
        var milestone = new Milestone()
        {
            ProjectId = _project.Id,
            Id = _milestone!.Id,
            Name = _milestoneTestDataForAddAndUpdate!.UpdatedName,
            Description = _milestoneTestDataForAddAndUpdate!.UpdatedDescription
        };

        var actualMilestone = MilestoneService.UpdateMilestone(milestone);
        _milestone = actualMilestone.Result;
        _logger.Info(milestone.ToString());

        Assert.AreEqual("AK Milestone Test 2 updated", _milestone.Name);
    }

    [Test]
    [Order(6)]
    public void DeleteMilestoneTest()
    {
        Debug.Assert(MilestoneService != null, nameof(MilestoneService) + " != null");
        var milestoneId = _milestone!.Id.ToString();
        var statusCode = MilestoneService.DeleteMilestone(milestoneId);
        var milestonesCount = MilestoneService.GetMilestones(_project.Id).Result.Size;
        _logger.Info(statusCode);

        Assert.AreEqual(HttpStatusCode.OK, statusCode);
        Assert.AreEqual(1, milestonesCount);
    }

    [Test]
    [Order(7)]
    public void DeleteProjectTest()
    {
        Debug.Assert(ProjectService != null, nameof(ProjectService) + " != null");
        _logger.Info(ProjectService.DeleteProject(_project.Id.ToString()));
    }
}