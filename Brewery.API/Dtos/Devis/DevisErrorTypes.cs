using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.API.Dtos.Devis
{
    public enum DevisErrorTypes
    {
        EmptyDevis = 1,
        WholeSalerNotFound = 2,
        DuplicateBeer = 3,
        BeerStockNotFound = 4,
        BeerQuantityTooHigh = 5
    }
}
