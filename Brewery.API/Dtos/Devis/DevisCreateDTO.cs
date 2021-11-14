using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos
{
    public class DevisCreateDTO
    {
        public int WholeSalerId { get; set; }
        public List<DevisCreateLineDTO> Lines { get; set; }
    }
}
