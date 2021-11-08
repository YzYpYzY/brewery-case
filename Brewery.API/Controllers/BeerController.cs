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
    public class BeerController : ControllerBase
    {
        private readonly ILogger<BeerController> _logger;
        private readonly BreweryDbContext _ctx;

        public BeerController(ILogger<BeerController> logger, BreweryDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        //Lister l’ensemble des bières par brasserie et les grossistes qui la vendent
        [HttpGet]
        public ActionResult<List<BeerDTO>> Get()
        {
            var dtos = _ctx.Beers
                .Include(b => b.Brewery)
                .Include(b => b.BeerStocks).ThenInclude(bs => bs.WholeSaler)
                .Select(b => new BeerDTO(b))
                .AsEnumerable()
                .OrderBy(b => b.Brewery.Name);

            return Ok(dtos.ToList());
        }

        //Création d’une nouvelle bière
        [HttpPost]
        public ActionResult<BeerDTO> Post(BeerCreateDTO dto)
        {
            var brewery = _ctx.Breweries.FirstOrDefault(b => b.Id == dto.BreweryId);
            if (brewery == null)
            {
                return NotFound($"Brewery with id {dto.BreweryId} doesn't exist.");
            }

            var entity = new BeerEntity(dto.Name, dto.AlcoholLevel, dto.Price);
            entity.Brewery = brewery;
            _ctx.Beers.Add(entity);
            _ctx.SaveChanges();

            return Ok(new BeerDTO(entity));
        }

        //Supprimer une bière d’un brasseur
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var beer = _ctx.Beers.FirstOrDefault(b => b.Id == id);
            if (beer == null)
            {
                return NotFound($"Beer with id {id} doesn't exist.");
            }

            _ctx.BeerStocks.RemoveRange(_ctx.BeerStocks.Where(bs => bs.Beer.Id == id));
            _ctx.Beers.Remove(beer);
            _ctx.SaveChanges();

            return Ok();
        }
    }
}
