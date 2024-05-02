using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //API key from environment variable
            var apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            var weatherClient = new WeatherApiClient(apiKey);
            var weatherService = new WeatherService(weatherClient);
            weatherService.DisplayWeatherData();

        }
    }
}
