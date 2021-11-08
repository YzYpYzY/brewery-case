using Brewery.Data.Entities;

namespace Brewery.API.Dtos
{
    public class WholeSalerDTO
    {
        public string Name { get; set; }

        public WholeSalerDTO(WholeSalerEntity wholeSaler)
        {
            this.Name = wholeSaler.Name;
        }
    }
}