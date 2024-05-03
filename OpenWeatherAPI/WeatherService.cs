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

    public void DisplayWeatherData(string cityName)
    {
        var response = _apiClient.GetWeatherRequest(cityName);
        var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
        Console.WriteLine(formattedResponse);
    }
}