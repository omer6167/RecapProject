using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
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
            modelBuilder.Entity<Rental>()
                .Property(r => r.RentDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CarImage>()
                .Property(car => car.Date)
                .HasDefaultValueSql("getdate()");


            //modelBuilder.Entity<User>()
            //    .Property(U => U.Name)
            //    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        }



        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        
    }
}
