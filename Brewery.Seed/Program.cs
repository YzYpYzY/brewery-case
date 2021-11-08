using Brewery.Data;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Fluent;
using System;

namespace Brewery.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                var context = new BreweryDbContext(new DbContextOptions<BreweryDbContext>());
                logger.Info("Seeding database.");
                var seedHelper = new SeedHelper(context, logger);
                seedHelper.Seed();
                logger.Info("Database seeded.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred while seeding the database.");
            }
        }
    }
}
