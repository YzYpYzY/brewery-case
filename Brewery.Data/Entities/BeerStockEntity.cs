namespace Brewery.Data.Entities
{
    public class BeerStockEntity
    {
        public int Id { get; set; }
        public WholeSalerEntity WholeSaler { get; set; }
        public BeerEntity Beer { get; set; }
        public int Quantity { get; set; }

        public BeerStockEntity(int quantity)
        {
            this.Quantity = quantity;
        }

        public BeerStockEntity(WholeSalerEntity wholeSaler, BeerEntity beer, int quantity): this(quantity)
        {
            this.WholeSaler = wholeSaler;
            this.Beer = beer;
        }
    }
}