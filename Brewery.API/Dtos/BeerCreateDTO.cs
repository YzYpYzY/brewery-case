namespace Brewery.API.Dtos
{
    public class BeerCreateDTO
    {
        public string Name { get; set; }
        public double AlcoholLevel { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
    }
}