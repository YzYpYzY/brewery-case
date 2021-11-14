using Brewery.Data.Entities;

namespace Brewery.API.Dtos
{
    public class BeerStockDTO
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int WholeSalerId { get; set; }
        public string WholeSalerName { get; set; }
        public int Quantity { get; set; }

        public BeerStockDTO(BeerStockEntity entity)
        {
            this.Id = entity.Id;
            this.BeerId = entity.Beer.Id;
            this.BeerName = entity.Beer.Name;
            this.WholeSalerId = entity.WholeSaler.Id;
            this.WholeSalerName = entity.WholeSaler.Name;
            this.Quantity = entity.Quantity;
        }

    }
}