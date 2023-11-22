using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.AccuWeather;

namespace ShopTARge22.Controllers
{
	public class AccuWeatherController : Controller
	{
		private readonly IAccuWeatherServices _accuWeatherServices;

		public AccuWeatherController
			(IAccuWeatherServices accuWeatherServices
			)

		{
			_accuWeatherServices = accuWeatherServices;
		}



		[HttpGet]
		public IActionResult Index()
		{
			//SearchCityViewModel model = new();

			return View();
		}

		[HttpPost]
		public IActionResult City(AccuWeatherCityViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("City", "AccuWeather", new { city = model.City });
			}

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> City(string city)
        {
            AccuWeatherResultDto dto = new();
            AccuWeatherLocationResultDto dto1 = new();

            dto1.City = city;

            //_accuWeatherServices.AccuWeatherGet(dto1);

            await _accuWeatherServices.AccuWeatherResult(dto, dto1);

            AccuWeatherViewModel vm = new();
            vm.City = dto1.City;
            vm.Temperature = dto.Temperature;
            vm.TempFeelsLike = dto.TempFeelsLike;
            vm.Humidity = dto.Humidity;
            vm.Pressure = dto.Pressure;
            vm.WindSpeed = dto.WindSpeed;
            vm.WeatherCondition = dto.WeatherCondition;


            return View(vm);
        }

    }
}


