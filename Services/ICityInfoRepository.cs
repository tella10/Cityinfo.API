using Cityinfo.API.Entities;
using System.Collections.Generic;

namespace Cityinfo.API.Services
{
    public interface ICityInfoRepository
   {
       IEnumerable<city> GetCities();

       city GetCity(int CityId, bool pointOfInterestId);

       IEnumerable<PointOfInterest> GetPointOfInterests(int CityId);

       PointOfInterest GetPointOfInterest(int CityId, int id);

       bool IsExist(int id);

       void Addpointofinterest(int CityId, PointOfInterest pointOfInterest);
       void Updatepointofinterest(int CityId, PointOfInterest pointOfInterest);

       void DeletePointOfInterest(PointOfInterest pointOfInterest);
       bool Save();
   }
}
