namespace Brewery.API.Dtos
{
    public class BeerStockUpdateDTO
    {
        public int BeerId { get; set; }
        public int WholeSalerId { get; set; }
        public int Quantity { get; set; }
    }
}