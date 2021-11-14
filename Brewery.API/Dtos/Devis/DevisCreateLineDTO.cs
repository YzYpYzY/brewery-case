using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos
{
    public class DevisCreateLineDTO
    {
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
