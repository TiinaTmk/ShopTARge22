using System;
using System.Net;
using System.Net.Http;
using Nancy.Json;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.ApplicationServices.Services
{
	public class AccuWeatherServices : IAccuWeatherServices
	{
		public async Task<OpenAccuWeatherResultDto> OpenAccuWeatherResult(OpenAccuWeatherResultDto dto)
		{

			{
				string apiKey = "RrVGfdIuGC7bP35fMhw74ldzSRSz9pBi";
				string url = $"https://dataservice.accuweather.com/locations/v1/cities/search?q={dto.Name}&apikey={apiKey}";

				using (WebClient client = new WebClient())
				{
					string json = client.DownloadString(url);
					AccuWeatherResponseRootDto accuweatherResult = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json);

					dto.ID = accuweatherResult.ID;
					dto.LocalizedName = accuweatherResult.LocalizedName;
					dto.EnglishName = accuweatherResult.EnglishName;
					dto.Level = accuweatherResult.Level;
					dto.LocalizedType = accuweatherResult.LocalizedType;
					dto.EnglishType = accuweatherResult.EnglishType;
					dto.CountryID = accuweatherResult.CountryID;
				}
				return dto;
			}
		}
	}
}

					


					










					
