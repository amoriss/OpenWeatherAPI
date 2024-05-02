using System;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherService
{
    private readonly WeatherApiClient _apiClient;

    public WeatherService(WeatherApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public void DisplayWeatherData()
    {
        var response = _apiClient.GetWeatherRequest("London");
        var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
        Console.WriteLine(formattedResponse);
    }
}