namespace Brewery.API.Dtos
{
    public class BeerStockCreateDTO
    {
        public int BeerId { get; set; }
        public int WholeSalerId { get; set; }
        public int Quantity { get; set; }
    }
}