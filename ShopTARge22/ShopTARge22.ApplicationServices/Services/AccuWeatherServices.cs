using System;
using System.Net;
using System.Net.Http;
using Nancy.Json;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.ApplicationServices.Services;


public class AccuWeatherServices : IAccuWeatherServices
{
    //apiKeyidAccuWeather = "RrVGfdIuGC7bP35fMhw74ldzSRSz9pBi";
    //dto1Key = "2541071";


    string idAccuWeather = "RrVGfdIuGC7bP35fMhw74ldzSRSz9pBi";
    public async Task<AccuWeatherLocationResultDto> AccuWeatherGet(AccuWeatherLocationResultDto dto1)
    {

        try
        {

            var url1 = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={idAccuWeather}&q={dto1.City}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url1);
                List<AccuWeatherLocationRootDto> accuGet = new JavaScriptSerializer().Deserialize<List<AccuWeatherLocationRootDto>>(json);

                dto1.Key = accuGet[0].Key;
                dto1.LocalizedName = accuGet[0].LocalizedName;
            }
        }
        catch (Exception ex) { Console.WriteLine("City not available. Try another city"); }
        return dto1;

    }

    public async Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto, AccuWeatherLocationResultDto dto1)
    {
        await AccuWeatherGet(dto1);

        if (!string.IsNullOrEmpty(dto1.Key))
        {
            string url = $"http://dataservice.accuweather.com/currentconditions/v1/{dto1.Key}?apikey={idAccuWeather}&details=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<AccuWeatherRootDto> accuweatherResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherRootDto>>(json);

                dto.Temperature = accuweatherResult[0].Temperature.Metric.Value;
                dto.TempFeelsLike = accuweatherResult[0].TempFeelsLike.Metric.Value;
                dto.Humidity = accuweatherResult[0].Humidity;
                dto.Pressure = accuweatherResult[0].Pressure.Metric.Value;
                dto.WindSpeed = accuweatherResult[0].WindSpeed.Speed.Metric.Value;
                dto.WeatherCondition = accuweatherResult[0].WeatherCondition;
            }
        }

        return dto;
    }

}
