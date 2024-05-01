using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            var weather = new WeatherApiClient();
            weather.DisplayWeatherData();

        }
    }
}
