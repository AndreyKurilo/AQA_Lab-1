using System.Net;
using System.Threading.Tasks;
using RestSharp;
using TestRail.ApiTesting;

namespace TestRail_Example.Services;

public class MilestoneService : IMilestonesService
{
    public Task<Milestone> GetMilestone(string mileStoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", projectId);
        
        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Milestones> GetMilestones()
    {
        throw new System.NotImplementedException();
    }

    public Task<Milestone> AddMilestone(Milestone milestone)
    {
        throw new System.NotImplementedException();
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone)
    {
        throw new System.NotImplementedException();
    }

    public HttpStatusCode DeleteMilestone(string mileStoneId)
    {
        throw new System.NotImplementedException();
    }
}