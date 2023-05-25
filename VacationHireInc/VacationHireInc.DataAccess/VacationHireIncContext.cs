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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
    }
}

