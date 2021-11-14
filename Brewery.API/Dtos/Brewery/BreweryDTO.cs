using Brewery.Data.Entities;

namespace Brewery.Dtos
{
    public class BreweryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BreweryDTO(BreweryEntity entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }
    }
}