using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Web;
using System.Threading.Tasks;
using PaddleBoarder.Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace PaddleBoarder.Services
{
    public class ApiWorker
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://api.openweathermap.org/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            //adds header to give json. to then parse into models
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<WeatherData> GetWeatherForcast(string city)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=ce7dd45c1a48dde971ef20b5b7dd3d16";

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string weatherResponseAsJsonString = await response.Content.ReadAsStringAsync();
                   
                    WeatherData weather = JsonConvert.DeserializeObject<WeatherData>(weatherResponseAsJsonString);
            
                    return weather;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

     

           

            //synchronous Client
          //  var client = new WebClient();
          //
          //  var content = client.DownloadString(url);
          //  var serializer = new JavaScriptSerializer();
          //  var jsonContent = serializer.Deserialize<Object>(content);
          //
          //  return jsonContent;
        

    }
}