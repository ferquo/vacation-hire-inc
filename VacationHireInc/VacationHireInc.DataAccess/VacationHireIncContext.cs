using System;
using Microsoft.EntityFrameworkCore;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess
{
	public class VacationHireIncContext : DbContext
	{
        public VacationHireIncContext(DbContextOptions<VacationHireIncContext> optionsBuilder)
            : base(optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the required rentable products
            modelBuilder.Entity<RentableProduct>().HasData(
                    new RentableProduct { Id = Guid.Parse("19847126-445E-48F7-97C7-1D25D71365D5"), Name = "Truck" },
                    new RentableProduct { Id = Guid.Parse("74641849-26EC-4A1C-BE8C-D7B4D6FFD83C"), Name = "Minivan" },
                    new RentableProduct { Id = Guid.Parse("448EDCD9-E7A0-47B3-975F-2E49DDB00040"), Name = "Sedan" }
                );
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<RentableProduct> RentableProducts { get; set; }
    }
}

