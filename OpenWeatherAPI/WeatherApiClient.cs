using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherApiClient
{
    private readonly HttpClient _client;
    private readonly string _apiKey;

    public WeatherApiClient(string apiKey)
    {
        _client = new HttpClient();
        _apiKey = apiKey;
    }

    public string GetWeatherRequest(string cityName)
    {
       //API endpoint
        var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={_apiKey}";
        
        //get response as a string
        var response = _client.GetStringAsync(weatherURL).Result;
        
        //return weather response as a string
        return response;
    }
}