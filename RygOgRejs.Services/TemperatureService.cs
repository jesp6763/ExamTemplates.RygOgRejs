using System;
using System.Net;
using Newtonsoft.Json;

namespace RygOgRejs.Services
{
    public static class TemperatureService
    {
        public static string GetTemperature(string destination)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString($"http://api.openweathermap.org/data/2.5/find?q={destination}&units=metric&appid=2a5b989adc59b59f198ee28ce3dbeeee");
            dynamic data = JsonConvert.DeserializeObject(json);

            if(data["list"][0]["main"] == null)
            {
                return "No temperature was found";
            }
            return $"{data["list"][0]["main"].temp} °C";
        }
    }
}


// OpenWeatherMap API Key: 2a5b989adc59b59f198ee28ce3dbeeee