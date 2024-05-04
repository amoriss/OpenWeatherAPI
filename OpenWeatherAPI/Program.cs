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
            
            //pass API key to the WeatherAPIClient
            var weatherClient = new WeatherApiClient(apiKey);
            
            //create instance of WeatherService while passing in the API key and Client through the constructor
            var weatherService = new WeatherService(weatherClient);
           
            //create instance of UserInputService class
            var userInputService = new UserInputService();
            
            //call GetCityName method
            string cityName = userInputService.GetCityName();
            
            //use city name from user input to call method to display weather info
            var data = await weatherService.DisplayWeatherData(cityName);
            Console.WriteLine(data.Main.Temp);
            
            //ask user if the want to enter in another city to check for weather
            string additionalAnswer = userInputService.AskForAnotherCity();
            while (additionalAnswer == "y" || additionalAnswer == "yes")
            {
                cityName = userInputService.GetCityName();
                weatherService.DisplayWeatherData(cityName);
                additionalAnswer = userInputService.AskForAnotherCity();
            }
            

        }
    }
}
