using PaddleBoarder.Models;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaddleBoarder.Services;
using System.Threading.Tasks;
using Newtonsoft;
using System.Web.UI;
using System.Diagnostics;

namespace PaddleBoarder.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //TODO returns main page. rename home.chtml and remove method above
        public ActionResult WeatherResponse()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetWeather(string city)
        {
            ApiWorker.InitializeClient();
            ApiWorker weatherApi= new ApiWorker();
            var response = await weatherApi.GetWeatherForcast(city);

            if (response != null)
            {
                ViewBag.Temp = response.main.temp;
                ViewBag.Desc = response.weather[0].description;

                DescriptionData idResponse = new DescriptionData { };

                ViewModel weatherView = new ViewModel {

                    IsRain = idResponse.IdRain.Contains(response.weather[0].id),
                    IsSun = idResponse.IdSun.Contains(response.weather[0].id),
                    IsCloud = idResponse.IdCloud.Contains(response.weather[0].id),
                    IsThunder = idResponse.IdThunder.Contains(response.weather[0].id)
                };

                return View("WeatherResponse", weatherView);

             }         
            
                return View("WeatherResponse");
        }    
        
        public ActionResult Book ()
        {
            return View();
        }
    }
}