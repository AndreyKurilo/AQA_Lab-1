using System.Net;
using System.Threading.Tasks;
using TestRail.ApiTesting;

namespace TestRail_Example.Services;

public interface IMilestonesService
{
    Task<Milestone> GetMilestone(string mileStoneId);
    Task<Milestones> GetMilestones(int project_id);
    Task<Milestone> AddMilestone(Milestone milestone);
    Task<Milestone> UpdateMilestone(Milestone milestone);
    HttpStatusCode DeleteMilestone(string mileStoneId);
}