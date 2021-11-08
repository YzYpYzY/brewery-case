using System.Collections.Generic;

namespace Brewery.Data.Entities
{
    public class BreweryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BeerEntity> Beers { get; set; }

        public BreweryEntity(string Name)
        {
            this.Name = Name;
        }
    }
}