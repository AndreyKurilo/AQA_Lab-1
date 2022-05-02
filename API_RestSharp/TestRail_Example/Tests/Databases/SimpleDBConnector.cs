using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace TestRail_Example.Tests.Databases;

public class SimpleDBConnector
{
    private static readonly Lazy<IConfiguration> SConfiguration;
    private static IConfiguration Configuration => SConfiguration.Value;

    static SimpleDBConnector()
    {
        SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    public SimpleDBConnector()
    {
        var connectionString =
            $"Host={DbSettings.Server};" +
            $"Port={DbSettings.Port};" +
            $"Database={DbSettings.Schema};" +
            $"User Id={DbSettings.Username};" +
            $"Password={DbSettings.Password};";

        Connection = new NpgsqlConnection(connectionString);
        Connection.Open();
    }
    
    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }

    public NpgsqlConnection Connection { get; }

    public void CloseConnection()
    {
        Connection.Close();
    }
    
    public static DbSettings DbSettings
    {
        get
        {
            var dbSettings = new DbSettings();
            var child = Configuration.GetSection("DbSettings");

            dbSettings.Driver = child["DB_Driver"];
            dbSettings.Server = child["DB_Server"];
            dbSettings.Port = child["DB_Port"];
            dbSettings.Schema = child["DB_Schema"];
            dbSettings.Username = child["DB_Username"];
            dbSettings.Password = child["DB_Password"];

            return dbSettings;
        }
    }
}