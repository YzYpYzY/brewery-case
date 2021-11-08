using System.Collections.Generic;
using System.Linq;
using Brewery.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BreweryDbContext>())
                {
                    //context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BreweryDbContext>())
                {
                    if (!context.Beers.Any())
                    {
                        var breweries = new List<BreweryEntity>(){
                            new BreweryEntity("Abbaye de Leffe"),
                            new BreweryEntity("Brasserie Lupulus"),
                            new BreweryEntity("Abbaye de Chimay"),
                            new BreweryEntity("Abbaye d'Orval"),
                            new BreweryEntity("Brasserie Dubuisson"),
                        };

                        var beers = new List<BeerEntity>() {
                            new BeerEntity("Leffe Blonde", 6, 1.5, breweries[0]),
                            new BeerEntity("Leffe Brune", 7, 1.5, breweries[0]),
                            new BeerEntity("Leffe Ruby", 8, 2, breweries[0]),
                            new BeerEntity("Tripick 8", 8, 1.8, breweries[1]),
                            new BeerEntity("Lupulus", 8.5, 2, breweries[1]),
                            new BeerEntity("Chimay Bleue", 9, 2, breweries[3]),
                            new BeerEntity("Orval", 7.2, 1.9, breweries[4]),
                            new BeerEntity("Bush ambrée", 12, 2.1, breweries[5])
                        };

                        foreach (var brewery in breweries)
                        {
                            context.Breweries.Add(brewery);
                        }

                        var wholeSalers = new List<WholeSalerEntity>() {
                            new WholeSalerEntity("GeneDrinks"),
                            new WholeSalerEntity("BeerAndWine"),
                            new WholeSalerEntity("Drink d'Annevoie")
                        };

                        var beerStocks = new List<BeerStockEntity>() {
                            new BeerStockEntity(wholeSalers[0], beers[0], 22),
                            new BeerStockEntity(wholeSalers[0], beers[1], 220),
                            new BeerStockEntity(wholeSalers[0], beers[2], 100),
                            new BeerStockEntity(wholeSalers[0], beers[3], 55),
                            new BeerStockEntity(wholeSalers[0], beers[4], 9),
                            new BeerStockEntity(wholeSalers[1], beers[3], 22),
                            new BeerStockEntity(wholeSalers[1], beers[4], 67),
                            new BeerStockEntity(wholeSalers[1], beers[5], 77),
                            new BeerStockEntity(wholeSalers[1], beers[6], 100),
                            new BeerStockEntity(wholeSalers[1], beers[7], 300),
                            new BeerStockEntity(wholeSalers[2], beers[1], 34),
                            new BeerStockEntity(wholeSalers[2], beers[2], 22),
                            new BeerStockEntity(wholeSalers[2], beers[3], 56),
                            new BeerStockEntity(wholeSalers[2], beers[4], 7),
                            new BeerStockEntity(wholeSalers[2], beers[5], 234),
                            new BeerStockEntity(wholeSalers[2], beers[6], 21)
                        };

                        foreach (var beerStock in beerStocks)
                        {
                            context.BeerStocks.Add(beerStock);
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}