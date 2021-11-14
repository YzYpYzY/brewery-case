using System.Collections.Generic;
using System.Linq;
using Brewery.Data.Entities;
using Brewery.Dtos;

namespace Brewery.API.Dtos
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholLevel { get; set; }
        public double Price { get; set; }
        public BreweryDTO Brewery { get; set; }
        public List<WholeSalerDTO> WholeSalers { get; set; }

        public BeerDTO(BeerEntity beer)
        {
            this.Id = beer.Id;
            this.Name = beer.Name;
            this.AlcoholLevel = beer.AlcoholLevel;
            this.Price = beer.Price;
            this.Brewery = new BreweryDTO(beer.Brewery);
            this.WholeSalers = beer.BeerStocks.Select(bs => new WholeSalerDTO(bs.WholeSaler)).ToList();
        }
    }
}