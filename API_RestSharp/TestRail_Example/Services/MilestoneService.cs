using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using TestRail.ApiTesting;
using TestRail_Example.Clients;

namespace TestRail_Example.Services;

public class MilestoneService : IMilestonesService, IDisposable
{
    private readonly RestClientExtended _client;

    public MilestoneService(RestClientExtended client)
    {
        _client = client;
    }


    public Task<Milestone> GetMilestone(string mileStoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}")
            .AddUrlSegment("milestone_id", mileStoneId);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestones> GetMilestones(int project_id)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestones/{project_id}")
            .AddUrlSegment("project_id", project_id);

        var milestones = _client.ExecuteAsync<Milestones>(request); 
        return milestones;
    }

    public Task<Milestone> AddMilestone(Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", milestone.ProjectId)
            .AddJsonBody(milestone);
        
        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/update_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestone.Id)
            .AddJsonBody(milestone);
        
        return _client.ExecuteAsync<Milestone>(request);

    }

    public HttpStatusCode DeleteMilestone(string mileStoneId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("project_id", mileStoneId)
            .AddJsonBody("{}");
        
        return _client.ExecuteAsync(request).Result.StatusCode;

    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);

    }
}