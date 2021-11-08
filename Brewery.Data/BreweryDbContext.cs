using Brewery.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brewery.Data
{
    public class BreweryDbContext : DbContext
    {
        public DbSet<BeerEntity> Beers { get; set; }
        public DbSet<BreweryEntity> Breweries { get; set; }
        public DbSet<WholeSalerEntity> WholeSalers { get; set; }
        public DbSet<BeerStockEntity> BeerStocks { get; set; }

        public BreweryDbContext() : base()
        { }

        public BreweryDbContext(DbContextOptions<BreweryDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerEntity>();
            modelBuilder.Entity<BreweryEntity>();
            modelBuilder.Entity<WholeSalerEntity>();
            modelBuilder.Entity<BeerStockEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source='../db.sqlite'");
        }

    }
}
