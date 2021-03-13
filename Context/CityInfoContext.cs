using Cityinfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cityinfo.API.Context
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
                
        }
        public DbSet<city> City  { get; set; }

        public DbSet<PointOfInterest> PointOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<city>()
                .HasData(
                    new city()
                    {
                        Id = 1,
                        Name = "Abuja",
                        Country = "Nigeria",
                        Description = "The capital of Nigeria"
                    },
                    new city()
                    {
                        Id = 2,
                        Name = "Accra",
                        Country = "Ghana",
                        Description = "The capital of Ghana"
                    },
                    new city()
                    {
                        Id = 3,
                        Name = "London",
                        Country = "United Kingdom",
                        Description = "The capital of United Kingdom"
                    },
                    new city()
                    {
                        Id = 4,
                        Name = "New York",
                        Country = "United State",
                        Description = "The famous state in United State"
                    }
                    );

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                    new PointOfInterest()
                    {
                        Id = 1,
                        CityId = 1,
                        Name = "Gwangalada",
                        Description = "The famous place in Abuja"
                    },
                    new PointOfInterest()
                    {
                        Id = 2,
                        CityId = 1,
                        Name = "Lagos",
                        Description = "The industrious city in Nigeria"
                    },
                    new PointOfInterest()
                    {
                        Id = 3,
                        CityId = 2,
                        Name = "Godison Park",
                        Description = "Everton Stadium in London UK"
                    },
                    new PointOfInterest()
                    {
                        Id = 4,
                        CityId = 3,
                        Name = "Silicon Valley",
                        Description = "The famous city in US for best technology innovation"
                    },
                    new PointOfInterest()
                    {
                        Id = 5,
                        CityId = 3,
                        Name = "Silicon Valley-1",
                        Description = "The famous city in US for best technology innovation"
                    },
                    new PointOfInterest()
                    {
                        Id = 6,
                        CityId = 4,
                        Name = "Silicon Valley-1",
                        Description = "The famous city in US for best technology innovation"
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
