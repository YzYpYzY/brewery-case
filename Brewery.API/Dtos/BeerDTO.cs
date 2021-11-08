using System.Collections.Generic;
using System.Linq;
using Brewery.Data.Entities;

namespace Brewery.API.Dtos
{
    public class BeerDTO
    {
        public string Name { get; set; }
        public double AlcoholLevel { get; set; }
        public double Price { get; set; }
        public string BreweryName { get; set; }
        public List<WholeSalerDTO> WholeSalers { get; set; }

        public BeerDTO(BeerEntity beer)
        {
            this.Name = beer.Name;
            this.AlcoholLevel = beer.AlcoholLevel;
            this.Price = beer.Price;
            this.BreweryName = beer.Brewery.Name;
            this.WholeSalers = beer.WholeSalers.Select(w => new WholeSalerDTO(w)).ToList();
        }
    }
}