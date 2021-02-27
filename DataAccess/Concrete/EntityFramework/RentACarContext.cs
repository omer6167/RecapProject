using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LocalHost; Database = RentACar; Trusted_Connection = True; User ID = SKUCUK;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rentals>()
                .Property(r => r.RentDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CarImages>()
                .Property(car => car.Date)
                .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<Users>()
                .Property(U => U.Name)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        }



        public DbSet<Car> Car { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Rentals> Rentals { get; set; }

    }
}
