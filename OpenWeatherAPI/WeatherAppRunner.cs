using System;
using System.Threading.Tasks;

namespace OpenWeatherAPI;

public class WeatherAppRunner
{
    private readonly WeatherService _weatherService;
    private readonly UserInputService _userInputService;

    public WeatherAppRunner(WeatherService weatherService, UserInputService userInputService)
    {
        _weatherService = weatherService;
        _userInputService = userInputService;
    }

    public async Task RunApp()
    {
        //get city from user
        string cityName = _userInputService.GetCityName();

        //get city temp
        var temperatureData = await _weatherService.GetTemperatureData(cityName);

        //display city temp
        Console.WriteLine($"{temperatureData} degrees");
        
        //allow user to enter in a city until they are done
        string additionalAnswer = _userInputService.AskForAnotherCity();
        while (additionalAnswer == "y" || additionalAnswer == "yes")
        {
            cityName = _userInputService.GetCityName();
            temperatureData = await _weatherService.GetTemperatureData(cityName);
            Console.WriteLine($"{temperatureData} degrees");
            additionalAnswer = _userInputService.AskForAnotherCity();
        }
    }
}