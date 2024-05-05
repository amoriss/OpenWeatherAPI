using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherService //service class handles data processing and transformation
{
    private readonly WeatherApiClient _apiClient;

    public WeatherService(WeatherApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    

    public static Root DeserializeWeatherData(string response)
    {
        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
        return myDeserializedClass;
    }
    public async Task<Root> GetWeatherData(string cityName)
    {
        var response = await _apiClient.GetWeatherRequest(cityName);
        var deserializedResponse = DeserializeWeatherData(response);
        return deserializedResponse;
    }

    public async Task<double> GetTemperatureData(string cityName)
    {
        var response = await _apiClient.GetWeatherRequest(cityName);
        var deserializedResponse = DeserializeWeatherData(response);
        return deserializedResponse.Main.Temp;
    }
}