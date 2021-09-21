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
        
        public ActionResult Index()
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

        //returns main page. rename home.chtml and remove method above
        public ActionResult WeatherResponse()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetWeather(string city)
        {
            ApiWorker.InitializeClient();

            ApiWorker weatherApi= new ApiWorker();



            // var JsonResponse = Json(weatherApi.GetWeatherForcast(city), JsonRequestBehavior.AllowGet);
            var response = await weatherApi.GetWeatherForcast(city);
            
             if (response != null)
             {

                ViewBag.Temp = response.main.temp;
                ViewBag.Desc = response.weather[0].description;
      
             }
          
             
                 return View("WeatherResponse");

        }

        
    }
}