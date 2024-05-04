using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPI;

public class WeatherService
{
    private readonly WeatherApiClient _apiClient;

    public WeatherService(WeatherApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<Root> DisplayWeatherData(string cityName)
    {
        var response = await _apiClient.GetWeatherRequest(cityName);
        if (response != null)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
            return myDeserializedClass;
        }

        return null;
    }
}