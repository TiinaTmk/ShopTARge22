using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.AccuWeatherDtos;
using ShopTARge22.Core.Dto.AccuWeatherLocationDtos;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface IAccuWeatherServices
	{
		Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto, AccuWeatherLocationResultDto dto1);
        Task<AccuWeatherLocationResultDto> AccuWeatherGet(AccuWeatherLocationResultDto dto1);
    }
}

        
      