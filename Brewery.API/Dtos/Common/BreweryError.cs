using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos.Common
{
    public class BreweryError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Infos { get; set; }

        public BreweryError(int code, string message, object infos = null)
        {
            Code = code;
            Message = message;
            Infos = infos;
        }
    }
}
