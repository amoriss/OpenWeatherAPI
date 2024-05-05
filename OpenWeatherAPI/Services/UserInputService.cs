using System;

namespace OpenWeatherAPI;

public class UserInputService
{
    public string GetCityName()
    {
        Console.WriteLine("Please enter in city name:");
        var cityName = Console.ReadLine();
        return cityName;
    }

    public string AskForAnotherCity()
    {
        Console.WriteLine("Do you want to enter in another city?");
        var answer = Console.ReadLine();
        return answer;
    }
    
}