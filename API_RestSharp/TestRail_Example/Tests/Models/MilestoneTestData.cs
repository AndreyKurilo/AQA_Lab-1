using System.Text.Json.Serialization;

namespace TestRail_Example.Tests.Models;

public class MilestoneTestData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("projectId")] public int ProjectId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("updatedName")] public string? UpdatedName { get; init; }
    [JsonPropertyName("updatedDescription")] public string? UpdatedDescription { get; set; }
}