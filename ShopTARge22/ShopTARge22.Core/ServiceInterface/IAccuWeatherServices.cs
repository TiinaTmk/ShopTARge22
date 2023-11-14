using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.AccuWeatherDtos;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface IAccuWeatherServices
	{
		Task<OpenAccuWeatherResultDto> OpenAccuWeatherResult(OpenAccuWeatherResultDto dto);
	}
}



