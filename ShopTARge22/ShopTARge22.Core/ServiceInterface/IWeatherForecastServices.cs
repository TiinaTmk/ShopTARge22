using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.WeatherDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IWeatherForecastServices

    {
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
