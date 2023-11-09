using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.CocktailsDtos
{
	public class CocktailRootDto
	{
		public Drink Drink { get; set; }
	}

	public class Drink
	{
		// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
		public class Root
		{
			[JsonPropertyName("idDrink")]
			public string IdDrink { get; set; }

			[JsonPropertyName("strDrink")]
			public string StrDrink { get; set; }

			[JsonPropertyName("strDrinkAlternate")]
			public object StrDrinkAlternate { get; set; }

			[JsonPropertyName("strTags")]
			public string StrTags { get; set; }

			[JsonPropertyName("strVideo")]
			public object StrVideo { get; set; }

			[JsonPropertyName("strCategory")]
			public string StrCategory { get; set; }

			[JsonPropertyName("strIBA")]
			public string StrIBA { get; set; }

			[JsonPropertyName("strAlcoholic")]
			public string StrAlcoholic { get; set; }

			[JsonPropertyName("strGlass")]
			public string StrGlass { get; set; }

			[JsonPropertyName("strInstructions")]
			public string StrInstructions { get; set; }

			[JsonPropertyName("strInstructionsES")]
			public object StrInstructionsES { get; set; }

			[JsonPropertyName("strInstructionsDE")]
			public string StrInstructionsDE { get; set; }

			[JsonPropertyName("strInstructionsFR")]
			public object StrInstructionsFR { get; set; }

			[JsonPropertyName("strInstructionsIT")]
			public string StrInstructionsIT { get; set; }

			[JsonPropertyName("strInstructionsZH-HANS")]
			public object StrInstructionsZHHANS { get; set; }

			[JsonPropertyName("strInstructionsZH-HANT")]
			public object StrInstructionsZHHANT { get; set; }

			[JsonPropertyName("strDrinkThumb")]
			public string StrDrinkThumb { get; set; }

			[JsonPropertyName("strIngredient1")]
			public string StrIngredient1 { get; set; }

			[JsonPropertyName("strIngredient2")]
			public string StrIngredient2 { get; set; }

			[JsonPropertyName("strIngredient3")]
			public string StrIngredient3 { get; set; }

			[JsonPropertyName("strIngredient4")]
			public string StrIngredient4 { get; set; }

			[JsonPropertyName("strIngredient5")]
			public object StrIngredient5 { get; set; }

			[JsonPropertyName("strIngredient6")]
			public object StrIngredient6 { get; set; }

			[JsonPropertyName("strIngredient7")]
			public object StrIngredient7 { get; set; }

			[JsonPropertyName("strIngredient8")]
			public object StrIngredient8 { get; set; }

			[JsonPropertyName("strIngredient9")]
			public object StrIngredient9 { get; set; }

			[JsonPropertyName("strIngredient10")]
			public object StrIngredient10 { get; set; }

			[JsonPropertyName("strIngredient11")]
			public object StrIngredient11 { get; set; }

			[JsonPropertyName("strIngredient12")]
			public object StrIngredient12 { get; set; }

			[JsonPropertyName("strIngredient13")]
			public object StrIngredient13 { get; set; }

			[JsonPropertyName("strIngredient14")]
			public object StrIngredient14 { get; set; }

			[JsonPropertyName("strIngredient15")]
			public object StrIngredient15 { get; set; }

			[JsonPropertyName("strMeasure1")]
			public string StrMeasure1 { get; set; }

			[JsonPropertyName("strMeasure2")]
			public string StrMeasure2 { get; set; }

			[JsonPropertyName("strMeasure3")]
			public string StrMeasure3 { get; set; }

			[JsonPropertyName("strMeasure4")]
			public object StrMeasure4 { get; set; }

			[JsonPropertyName("strMeasure5")]
			public object StrMeasure5 { get; set; }

			[JsonPropertyName("strMeasure6")]
			public object StrMeasure6 { get; set; }

			[JsonPropertyName("strMeasure7")]
			public object StrMeasure7 { get; set; }

			[JsonPropertyName("strMeasure8")]
			public object StrMeasure8 { get; set; }

			[JsonPropertyName("strMeasure9")]
			public object StrMeasure9 { get; set; }

			[JsonPropertyName("strMeasure10")]
			public object StrMeasure10 { get; set; }

			[JsonPropertyName("strMeasure11")]
			public object StrMeasure11 { get; set; }

			[JsonPropertyName("strMeasure12")]
			public object StrMeasure12 { get; set; }

			[JsonPropertyName("strMeasure13")]
			public object StrMeasure13 { get; set; }

			[JsonPropertyName("strMeasure14")]
			public object StrMeasure14 { get; set; }

			[JsonPropertyName("strMeasure15")]
			public object StrMeasure15 { get; set; }

			[JsonPropertyName("strImageSource")]
			public string StrImageSource { get; set; }

			[JsonPropertyName("strImageAttribution")]
			public string StrImageAttribution { get; set; }

			[JsonPropertyName("strCreativeCommonsConfirmed")]
			public string StrCreativeCommonsConfirmed { get; set; }

			[JsonPropertyName("dateModified")]
			public string DateModified { get; set; }
		}


	}
}
