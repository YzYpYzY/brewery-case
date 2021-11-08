using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewery.API.Dtos;
using Brewery.Data;
using Brewery.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brewery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerStockController : ControllerBase
    {
        private readonly ILogger<BeerStockController> _logger;
        private readonly BreweryDbContext _ctx;

        public BeerStockController(ILogger<BeerStockController> logger, BreweryDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        //Ajoute la vente d’une bière existante, à un grossiste existant
        [HttpPost]
        public ActionResult<BeerStockDTO> Post(BeerStockCreateDTO dto)
        {
            var wholeSaler = _ctx.WholeSalers.FirstOrDefault(w => w.Id == dto.WholeSalerId);
            if (wholeSaler == null)
            {
                return NotFound($"WholeSaler with id {dto.WholeSalerId} doesn't exist.");
            }
            var beer = _ctx.Beers.FirstOrDefault(b => b.Id == dto.BeerId);
            if (beer == null)
            {
                return NotFound($"Beer with id {dto.BeerId} doesn't exist.");
            }

            var entity = new BeerStockEntity(wholeSaler, beer, dto.Quantity);
            _ctx.BeerStocks.Add(entity);
            _ctx.SaveChanges();

            return Ok(new BeerStockDTO(entity));
        }

        //Mise à jour de la quantité restante d’une bière chez un grossiste
        [HttpPut]
        [Route("{id}")]
        public ActionResult<BeerStockDTO> Put(int id, int newQuantity)
        {
            var entity = _ctx.BeerStocks
                .Include(bs => bs.Beer)
                .Include(bs => bs.WholeSaler)
                .FirstOrDefault(b => b.Id == id);
            if (entity == null)
            {
                return NotFound($"BeerStock with id {id} doesn't exist.");
            }

            entity.Quantity = newQuantity;
            _ctx.SaveChanges();

            return Ok(new BeerStockDTO(entity));
        }
    }
}
