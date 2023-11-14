using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
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
		public IActionResult SearchCity(SearchAccuWeatherCityViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("City", "WeatherForecasts", new { city = model.CityName });
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult City(string localizedName)
		{
			OpenAccuWeatherResultDto dto = new();
			dto.LocalizedName = localizedName;


			_accuWeatherServices.OpenAccuWeatherResult(dto);
			OpenAccuWeatherViewModel vm = new();


			vm.LocalizedName = dto.LocalizedName;
			vm.EnglishName = dto.EnglishName;
			vm.Level = dto.Level;
			vm.LocalizedType = dto.LocalizedType;
			vm.EnglishType = dto.EnglishType;
			vm.CountryID = dto.CountryID;
			


			return View(vm);
		}
	}
}

	
