using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Protocols;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc.Async;

namespace PaddleBoarder.Models
{
    public class Weather1
    {
  

        public WeatherData GetWeatherForcast(string city)
        {

          string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=ce7dd45c1a48dde971ef20b5b7dd3d16";

   

            //synchronous Client
            var client = new WebClient();
            
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<WeatherData>(content);

            return jsonContent;
        }
    }
}