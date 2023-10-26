using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<OpenChuckNorrisResultDto> ChuckNorrisRandomJokes(OpenChuckNorrisResultDto dto);
    }
}




  