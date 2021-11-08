﻿// <auto-generated />
using System;
using Brewery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Brewery.Data.Migrations
{
    [DbContext(typeof(BreweryDbContext))]
    partial class BreweryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Brewery.Data.Entities.BeerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AlcoholLevel")
                        .HasColumnType("REAL");

                    b.Property<int?>("BreweryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BeerStockEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BeerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WholeSalerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholeSalerId");

                    b.ToTable("BeerStocks");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BreweryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("Brewery.Data.Entities.WholeSalerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WholeSalers");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BeerEntity", b =>
                {
                    b.HasOne("Brewery.Data.Entities.BreweryEntity", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId");

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BeerStockEntity", b =>
                {
                    b.HasOne("Brewery.Data.Entities.BeerEntity", "Beer")
                        .WithMany("BeerStocks")
                        .HasForeignKey("BeerId");

                    b.HasOne("Brewery.Data.Entities.WholeSalerEntity", "WholeSaler")
                        .WithMany("BeerStocks")
                        .HasForeignKey("WholeSalerId");

                    b.Navigation("Beer");

                    b.Navigation("WholeSaler");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BeerEntity", b =>
                {
                    b.Navigation("BeerStocks");
                });

            modelBuilder.Entity("Brewery.Data.Entities.BreweryEntity", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("Brewery.Data.Entities.WholeSalerEntity", b =>
                {
                    b.Navigation("BeerStocks");
                });
#pragma warning restore 612, 618
        }
    }
}