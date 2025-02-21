using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Gamestore.Tests.API;

[TestFixture]
public class ApiIntegrationTests
{
    private HttpClient _client;
    private WebApplicationFactory<Gamestore.API.Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Gamestore.API.Program>();
        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task GetGames_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/api/games");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}