using System.Collections.Generic;
using NLog;
using Npgsql;
using TestRail_Example.Tests.Models;

namespace TestRail_Example.Tests.Services;

public class MilestoneTestDataService
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public MilestoneTestDataService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<MilestoneTestData> GetAllEMilestoneTestData()
    {
        var milestoneTestDataList = new List<MilestoneTestData>();

        // Retrieve all rows
        using var cmd = new NpgsqlCommand(
            "SELECT * FROM \"milestonesDataForTests\";",
            _connection);
        
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var milestoneTestData = new MilestoneTestData
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description")),
                UpdatedName = reader.GetString(reader.GetOrdinal("updatedName")),
                UpdatedDescription = reader.GetString(reader.GetOrdinal("updatedDescription"))
            };

            _logger.Info(milestoneTestData.ToString);

            milestoneTestDataList.Add(milestoneTestData);
        }

        return milestoneTestDataList;
    }
}