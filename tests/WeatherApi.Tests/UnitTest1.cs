using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WeatherApi.Tests;

public class WeatherForecastTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsFiveValidForecasts()
    {
        // Arrange
        using var client = _factory.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost"),
                AllowAutoRedirect = false
            });

        // Act
        using var response = await client.GetAsync("/weatherforecast");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(
            "application/json",
            response.Content.Headers.ContentType?.MediaType);

        using var json = JsonDocument.Parse(
            await response.Content.ReadAsStringAsync());

        var forecasts = json.RootElement;

        Assert.Equal(JsonValueKind.Array, forecasts.ValueKind);
        Assert.Equal(51, forecasts.GetArrayLength());

        foreach (var forecast in forecasts.EnumerateArray())
        {
            Assert.InRange(
                forecast.GetProperty("temperatureC").GetInt32(),
                -21,
                54);

            Assert.False(string.IsNullOrWhiteSpace(
                forecast.GetProperty("summary").GetString()));
        }
    }
}