using Cityinfo.API.Models;
using System.Collections.Generic;

namespace Cityinfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CitiesDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CitiesDto>()
            {
                new CitiesDto()
                {
                    Id = 1,
                    Name = "Lagos",
                    Description = "The state of Business in Nigeria",
                    Country = "Nigeria",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Ikeja",
                            Description = "The capital of Lagos State in Nigeria"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Ajegunle",
                            Description = "The most populated dense part of Lagos State in Nigeria"
                        }
                    } 

                },
                new CitiesDto()
                {
                    Id = 2,
                    Name = "London",
                    Description = "Situated in UK as the one of the fastest growing city",
                    Country = "United Kingdom",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Loughboruogh",
                            Description = "One of the most famous in London"
                        }
                    }
                },
                new CitiesDto()
                {
                    Id = 3,
                    Name = "Silicon Valley",
                    Description = "The state of the heart for amazing technologies innovation in US",
                    Country = "United State",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Pot1",
                            Description = "Situated in US"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Pot2",
                            Description = "The most populated dense part in US"
                        }
                    }
                },
                new CitiesDto()
                {
                    Id = 4,
                    Name = "Abuja",
                    Description = "The capital state of Nigeria",
                    Country = "Nigeria",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Ikeja",
                            Description = "The capital of Lagos State in Nigeria"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 7,
                            Name = "Ajegunle",
                            Description = "The most populated dense part of Lagos State in Nigeria"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Ikeja",
                            Description = "The capital of Lagos State in Nigeria"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 9,
                            Name = "Ajegunle",
                            Description = "The most populated dense part of Lagos State in Nigeria"
                        },
                    }

                },
                new CitiesDto()
                {
                    Id = 5,
                    Name = "Accra",
                    Description = "The capital state of Ghana",
                    Country = "Ghana",
                    PointOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 10,
                            Name = "Pot1",
                            Description = "One of the most famous in Ghana"
                        }
                    }

                }
            };
        }

    }
}
