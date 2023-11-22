using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.AccuWeather
{
	public class AccuWeatherCityViewModel
	{
		[Required(ErrorMessage = "You must enter a city name!")]
		[RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city Name greater than 2 and lesser than 20 characters")]
		[Display(Name = "City")]
		public string City { get; set; }
	}
}

   