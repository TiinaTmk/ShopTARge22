using System.Net;
using Nancy.Json;
using ShopTARge22.Core.Dto.CocktailsDtos;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.ApplicationServices.Services
{
	public class CocktailServices : ICocktailServices
	{
		public async Task<CocktailResultDto> GetCocktails(CocktailResultDto dto)
		{
			string apiKey = "1";
			string apiCallUrl = "https://www.thecocktaildb.com/api/json/v1/{apiKey}/search.php?s={dto.StrDrink}";

			using (WebClient client = new())
			{
				string json = client.DownloadString(apiCallUrl);
				CocktailRootDto cocktailResult = new JavaScriptSerializer().Deserialize<CocktailRootDto>(json);

				dto.IdDrink = cocktailResult.Drink.IdDrink;
				dto.StrDrink = cocktailResult.Drink.StrDrink;
				dto.StrDrinkAlternate = cocktailResult.Drink.StrDrinkAlternate;
				dto.StrTags = cocktailResult.Drink.StrVideo;
				dto.StrVideo = cocktailResult.Drink.StrVideo;
				dto.StrCategory = cocktailResult.Drink.StrCategory;
				dto.StrIBA = cocktailResult.Drink.StrIBA;
				dto.StrAlcoholic = cocktailResult.Drink.StrAlcoholic;
				dto.StrGlass = cocktailResult.Drink.StrGlass;
				dto.StrInstructions = cocktailResult.Drink.StrInstructions;
				dto.StrInstructionsES = cocktailResult.Drink.StrInstructionsES;
				dto.StrInstructionsDE = cocktailResult.Drink.StrInstructionsDE;
				dto.StrInstructionsFR = cocktailResult.Drink.StrInstructionsFR;
				dto.StrInstructionsIT = cocktailResult.Drink.StrInstructionsIT;
				dto.StrInstructionsZHHANS = cocktailResult.Drink.StrInstructionsZHHANS;
				dto.StrInstructionsZHHANT = cocktailResult.Drink.StrInstructionsZHHANT;
				dto.StrDrinkThumb = cocktailResult.Drink.StrDrinkThumb;
				dto.StrIngredient1 = cocktailResult.Drink.StrIngredient1;
				dto.StrIngredient2 = cocktailResult.Drink.StrIngredient2;
				dto.StrIngredient3 = cocktailResult.Drink.StrIngredient3;
				dto.StrIngredient4 = cocktailResult.Drink.StrIngredient4;
				dto.StrIngredient5 = cocktailResult.Drink.StrIngredient5;
				dto.StrIngredient6 = cocktailResult.Drink.StrIngredient6;
				dto.StrIngredient7 = cocktailResult.Drink.StrIngredient7;
				dto.StrIngredient8 = cocktailResult.Drink.StrIngredient8;
				dto.StrIngredient9 = cocktailResult.Drink.StrIngredient9;
				dto.StrIngredient10 = cocktailResult.Drink.StrIngredient10;
				dto.StrIngredient11= cocktailResult.Drink.StrIngredient11;
				dto.StrIngredient12 = cocktailResult.Drink.StrIngredient12;
				dto.StrIngredient13 = cocktailResult.Drink.StrIngredient13;
				dto.StrIngredient14 = cocktailResult.Drink.StrIngredient14;
				dto.StrIngredient15 = cocktailResult.Drink.StrIngredient15;
				dto.StrMeasure1 = cocktailResult.Drink.StrMeasure1;
				dto.StrMeasure2 = cocktailResult.Drink.StrMeasure2;
				dto.StrMeasure3 = cocktailResult.Drink.StrMeasure3;
				dto.StrMeasure4 = cocktailResult.Drink.StrMeasure4;
				dto.StrMeasure5 = cocktailResult.Drink.StrMeasure5;
				dto.StrMeasure6 = cocktailResult.Drink.StrMeasure6;
				dto.StrMeasure7 = cocktailResult.Drink.StrMeasure7;
				dto.StrMeasure8 = cocktailResult.Drink.StrMeasure8;
				dto.StrMeasure9 = cocktailResult.Drink.StrMeasure9;
				dto.StrMeasure10 = cocktailResult.Drink.StrMeasure10;
				dto.StrMeasure11 = cocktailResult.Drink.StrMeasure11;
				dto.StrMeasure12 = cocktailResult.Drink.StrMeasure12;
				dto.StrMeasure13 = cocktailResult.Drink.StrMeasure13;
				dto.StrMeasure14 = cocktailResult.Drink.StrMeasure14;
				dto.StrMeasure15 = cocktailResult.Drink.StrMeasure15;
				dto.StrImageSource = cocktailResult.Drink.StrImageSource;
				dto.StrImageAttribution = cocktailResult.Drink.StrImageAttribution;
				dto.StrCreativeCommonsConfirmed = cocktailResult.Drink.StrCreativeCommonsConfirmed;
				dto.DateModified = cocktailResult.Drink.DateModified;



			}

				return dto;
		}
	}
}
