using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherApiClient //handles API communication and receives raw data
{
    private readonly HttpClient _client;
    private readonly string _apiKey;

    public WeatherApiClient(string apiKey)
    {
        _client = new HttpClient();
        _apiKey = apiKey;
    }

    public async Task<string> GetWeatherRequest(string cityName)
    {
       //API endpoint
        var weatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={_apiKey}";
        
        //get response as a string
        var response = await _client.GetStringAsync(weatherUrl);
        
        //return weather response as a string
        return response;
    }
}