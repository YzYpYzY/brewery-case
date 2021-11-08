using System.Collections.Generic;

namespace Brewery.Data.Entities
{
    public class BeerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlcoholLevel { get; set; }
        public double Price { get; set; }
        public BreweryEntity Brewery { get; set; }
        public List<BeerStockEntity> BeerStocks { get; set; }

        public BeerEntity(string name, double alcoholLevel, double price)
        {
            this.Name = name;
            this.AlcoholLevel = alcoholLevel;
            this.Price = price;
            this.BeerStocks = new List<BeerStockEntity>();
        }

        public BeerEntity(string name, double alcoholLevel, double price, BreweryEntity brewery) : this(name, alcoholLevel, price)
        {
            this.Brewery = brewery;
        }
    }
}