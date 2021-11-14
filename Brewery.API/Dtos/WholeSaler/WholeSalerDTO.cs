using Brewery.Data.Entities;

namespace Brewery.API.Dtos
{
    public class WholeSalerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WholeSalerDTO(WholeSalerEntity wholeSaler)
        {
            this.Id = wholeSaler.Id;
            this.Name = wholeSaler.Name;
        }
    }
}