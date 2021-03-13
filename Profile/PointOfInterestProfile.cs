namespace Cityinfo.API.Profile
{
    public class PointOfInterestProfile : AutoMapper.Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<Entities.PointOfInterest, PointOfInterestDto>();
            CreateMap<Models.CreatedPointOfInterest, Entities.PointOfInterest>();
            CreateMap<Models.UpdatePointOfInterest, Entities.PointOfInterest>().ReverseMap();
        }
    }
}
