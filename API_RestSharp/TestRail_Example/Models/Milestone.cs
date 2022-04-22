using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestRail.ApiTesting;

public record Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("projectId")] public int ProjectId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("completed_on")] public string? CompletedOn { get; set; }
    [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("due_on")] public string? DueOn { get; set; }
    [JsonPropertyName("refs")] public string Refs { get; set; }


//"completed_on": 1389968184,
//"description": "...",
//"due_on": 1391968184,
//"id": 1,
//"is_completed": true,
//"name": "Release 1.5",
//"project_id": 1,
//"refs": "RF-1, RF-2",
//"url": "http:///testrail/index.php?/milestones/view/1"
}