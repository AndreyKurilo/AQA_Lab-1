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

}