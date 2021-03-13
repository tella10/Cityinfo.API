using System.Collections.Generic;

namespace Cityinfo.API.Models
{
    public class CitiesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public int PointOfInterestCount { get
        {
           return PointOfInterest.Count;
        }}

        public ICollection<PointOfInterestDto> PointOfInterest { get; set; } = new List<PointOfInterestDto>();


    }
}
