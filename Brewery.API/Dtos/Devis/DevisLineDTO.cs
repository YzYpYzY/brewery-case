using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos
{
    public class DevisLineDTO
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public DevisLineDTO(int beerId, string beerName, int quantity, double unitPrice)
        {
            BeerId = beerId;
            BeerName = beerName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
