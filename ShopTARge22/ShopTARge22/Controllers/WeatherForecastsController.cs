using Microsoft.AspNetCore.Mvc;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.Forecast;

namespace ShopTARge22.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastServices weatherForecastServices;

        public WeatherForecastsController
            (IWeatherForecastServices _weatherForecastServices
            )
         
            {
            _weatherForecastServices = weatherForecastServices;
            }
   


        [HttpGet]
        public IActionResult Index()
        {
        SearchCityViewModel model = new();

            return View();
        }
    }
}
