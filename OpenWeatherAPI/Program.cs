using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace OpenWeatherAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //API key from environment variable
            var apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            
            //client
            var client = new WeatherApiClient(apiKey);
            
            //services
            var weatherService = new WeatherService(client);
            var userInputService = new UserInputService();
            
            //run app
            var weatherAppRunner = new WeatherAppRunner(weatherService, userInputService);
            await weatherAppRunner.RunApp();
            

        }
    }
}
