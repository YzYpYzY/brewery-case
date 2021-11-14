using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewery.API.Dtos;
using Brewery.API.Dtos.Common;
using Brewery.API.Dtos.Devis;
using Brewery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brewery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevisController : ControllerBase
    {
        private readonly ILogger<DevisController> _logger;
        private readonly BreweryDbContext _ctx;

        public DevisController(ILogger<DevisController> logger, BreweryDbContext ctx)
        {
            _ctx = ctx;
            _logger = logger;
        }

        // Demander un devis à un grossiste, en cas de succès, la méthode renvoie un prix et un récapitulatif, en cas d’erreur, elle renvoie une exception et un message pour expliquer la raison
        // o La commande ne peut pas être vide
        // o Le grossiste doit exister
        // o Il ne peut pas y avoir de doublon dans la commande
        // o Le nombre de bières commandé ne doit pas être supérieur au stock du grossiste
        // o La bière doit être vendue par le grossiste
        // o Une réduction de 10 % est appliquée au-dessus de 10 boissons
        // o Une réduction de 20 % est appliquée au-dessus de 20 boissons
        [HttpPost]
        public ActionResult<List<DevisDTO>> Post(DevisCreateDTO createDto)
        {
            if (createDto.Lines.Count == 0 || createDto.Lines.All(l => l.Quantity == 0))
            {
                return BadRequest(new BreweryError((int)DevisErrorTypes.EmptyDevis, "La commande ne peut pas être vide"));
            }

            var wholeSaler = _ctx.WholeSalers.FirstOrDefault(ws => ws.Id == createDto.WholeSalerId);
            if (wholeSaler == null)
            {
                return BadRequest(new BreweryError((int)DevisErrorTypes.WholeSalerNotFound, $"Le grossiste doit exister"));
            }

            var ids = new SortedSet<int>();
            var devisDTO = new DevisDTO(createDto.WholeSalerId);

            foreach (var line in createDto.Lines)
            {
                if (ids.Contains(line.BeerId))
                {
                    return BadRequest(new BreweryError((int)DevisErrorTypes.DuplicateBeer, $"Il ne peut pas y avoir de doublon dans la commande", new { BeerId = line.BeerId }));
                } 
                else
                {
                    ids.Add(line.BeerId);
                    var beerStock = _ctx.BeerStocks
                        .Include(bs => bs.Beer)
                        .FirstOrDefault(bs => bs.Beer.Id == line.BeerId && bs.WholeSaler.Id == wholeSaler.Id);
                    if(beerStock == null)
                    {
                        return BadRequest(new BreweryError((int)DevisErrorTypes.BeerStockNotFound, $"La bière doit être vendue par le grossiste", new { BeerId = line.BeerId }));
                    } 
                    else if(beerStock.Quantity < line.Quantity)
                    {
                        return BadRequest(new BreweryError((int)DevisErrorTypes.BeerQuantityTooHigh, $"Le nombre de bières commandé ne doit pas être supérieur au stock du grossiste", new { BeerId = line.BeerId, WholeSalerQuantity = beerStock.Quantity }));
                    }
                    devisDTO.Lines.Add(new DevisLineDTO(line.BeerId, beerStock.Beer.Name, line.Quantity, beerStock.Beer.Price));
                    devisDTO.FinalPriceOOT += line.Quantity * beerStock.Beer.Price;
                }
            }

            computeDiscount(devisDTO);

            return Ok(devisDTO);

        }

        private void computeDiscount(DevisDTO devis)
        {
            var beerCount = devis.Lines.Sum(line => line.Quantity);
            var discountPercentage = 0;

            if (beerCount > 20)
            {
                discountPercentage = 20;

            } 
            else if(beerCount > 10)
            {
                discountPercentage = 10;
            }

            devis.Discount = devis.FinalPriceOOT * discountPercentage / 100;
            devis.FinalPriceOOT -= devis.Discount;
        }

    }
}
