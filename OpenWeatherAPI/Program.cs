using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var client = new HttpClient();
            //Console.WriteLine("Please enter your API key:");
            var apiKey = "4d732ddc83b81b6951094c4a0b8a08c2";


            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Please enter the city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
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
}
