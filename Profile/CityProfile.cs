namespace Cityinfo.API.Profile
{
    public class CityProfile : AutoMapper.Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.city, Models.CityWithoutPointOfInterestDto>();

            CreateMap<Entities.city, Models.CitiesDto>();
        }
    }
}
