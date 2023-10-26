using System.Net;
using Nancy.Json;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.ServiceInterface;
namespace ShopTARge22.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<OpenChuckNorrisResultDto> ChuckNorrisRandomJokes(OpenChuckNorrisResultDto dto)
        {
            
            string url = $"https://api.chucknorris.io/jokes/random";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                ChuckNorrisResponseRootDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseRootDto>(json);

                dto.Categories = chuckNorrisResult.Categories;
                dto.Created_At = chuckNorrisResult.Created_at;
                dto.Icon_url = chuckNorrisResult.Icon_url;
                dto.Updated_At = chuckNorrisResult.Updated_at;
                dto.Id = chuckNorrisResult.Id;
                dto.Url = chuckNorrisResult.Url;
                dto.Value = chuckNorrisResult.Value;


            }
            return dto;
        }
    }
}
