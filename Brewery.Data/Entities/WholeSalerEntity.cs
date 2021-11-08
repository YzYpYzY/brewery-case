using System.Collections.Generic;

namespace Brewery.Data.Entities
{
    public class WholeSalerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BeerStockEntity> BeerStocks { get; set; }

        public WholeSalerEntity(string name)
        {
            this.Name = name;
            this.BeerStocks = new List<BeerStockEntity>();
        }
    }
}