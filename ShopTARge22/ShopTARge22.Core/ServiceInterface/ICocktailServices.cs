using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.CocktailsDtos;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface ICocktailServices
	{
		Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
	}
}
