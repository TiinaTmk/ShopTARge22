using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.ChuckNorrisDtos
{

    public class OpenChuckNorrisResultDto

    {
        public List<object> Categories { get; set; }
        public string Created_At { get; set; }
        public string Icon_url { get; set; }
        public string Id { get; set; }
        public string Updated_At { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }

    }
}