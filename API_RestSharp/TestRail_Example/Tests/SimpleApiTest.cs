using System;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using TestRail_Example.Configuration;

namespace TestRail_Example.Tests;

public class SimpleApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public async Task GetProjectTest()
    {
        var client = new RestClient(Configurator.AppSettings.URL);
        client.Authenticator = new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password);

        var request = new RestRequest("index.php?/api/v2/get_projects", Method.Get);
        var response = await client.GetAsync(request);

        _logger.Info(response.StatusCode);
        _logger.Info(response.Content);
    }
}