using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherApiClient
{
    private readonly HttpClient _client;

    public WeatherApiClient()
    {
        _client = new HttpClient();
    }

    public void DisplayWeatherData()
    {
        var apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");


        while (true)
        {

            Console.WriteLine();
            Console.WriteLine("Please enter the city name:");
            var cityName = Console.ReadLine();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";
            
            var response = _client.GetStringAsync(weatherURL).Result;
            var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
            Console.WriteLine(formattedResponse);
            Console.WriteLine();
            Console.WriteLine("Would you like to enter a different city?");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "no" || userInput.ToLower() == "n")
            {
                break; 
            }

        }
    }
}