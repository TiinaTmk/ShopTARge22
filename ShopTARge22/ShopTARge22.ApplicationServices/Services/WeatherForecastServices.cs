using System.Net;
using Nancy.Json;
using ShopTARge22.Core.Dto.WeatherDtos;
using ShopTARge22.Core.ServiceInterface;
namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpenWeather = "your password";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";

            //1. mis peab tegema andmetega api call puhul -
            //Esimene samm on saata päring API-le, et saada soovitud andmed.
            //Selleks võite kasutada .NET-i sisseehitatud HttpClient klassi.

            //2. andmed tulevad JSON kujul siia ja mis peab tegema -
            //JSON - andmete deserialiseerimine:
            //Kui olete saanud API vastuse, mis on JSON kujul,
            //peate need muutma C# objektideks.
            //Selleks saate kasutada JSON deserialiseerimisraamatukogusid,
            //näiteks Newtonsoft.Json (JSON.NET) või C# 8 sisseehitatud System.Text.Json.

            //et need muuta C# - Loomulikult peate looma C# klassi (MyDataModel näites),
            //mis peegeldab API-vastuse JSON-struktuuri.
            //Kasutades JSON deserialiseerimisraamatukogu,
            //saate muuta JSON-andmed C# objektideks,
            //millele saate seejärel juurde pääseda ja nendega töötada.

            //3. Kui leiate 1. ja 2. vastuse, siis leida mingi näide
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<WeatherResponseRootDto>(json);
            }
            return null; 
        }
    }
}
