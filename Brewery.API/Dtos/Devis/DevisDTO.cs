using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos
{
    public class DevisDTO
    {
        public int WholeSalerId { get; set; }
        public List<DevisLineDTO> Lines { get; set; } = new List<DevisLineDTO>();
        public double Discount { get; set; } = 0;
        public double FinalPriceOOT { get; set; } = 0;

        public DevisDTO(int wholeSalerId)
        {
            WholeSalerId = wholeSalerId;
        }
    }
}
