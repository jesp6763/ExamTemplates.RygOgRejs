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
            string json = client.DownloadString("http://samples.openweathermap.org/data/2.5/find?q=London&units=metric&appid=b1b15e88fa797225412429c1c50c122a1");
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