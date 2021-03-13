using Cityinfo.API.Context;
using Cityinfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cityinfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository

    {
        private readonly CityInfoContext _cityInfocontext;


        public CityInfoRepository(CityInfoContext cityInfocontext)
        {
            _cityInfocontext = cityInfocontext ?? throw new ArgumentNullException(nameof(cityInfocontext));
        }
        public IEnumerable<city> GetCities()
        {
            return _cityInfocontext.City.OrderBy(c => c.Name).ToList();
        }

        public city GetCity(int CityId , bool pointOfInterestId)
        {
            if (pointOfInterestId)
            {
                return _cityInfocontext.City
                    .Include(c => c.PointOfInterest)
                    .FirstOrDefault(c => c.Id == CityId);
            }

            return _cityInfocontext.City
                .FirstOrDefault(c => c.Id == CityId);
        }

        public IEnumerable<PointOfInterest> GetPointOfInterests(int CityId)
        { 
            return _cityInfocontext.PointOfInterest
                .Where(p => p.CityId == CityId)
                .ToList();

        }

        public PointOfInterest GetPointOfInterest(int CityId, int id)
        {
            return _cityInfocontext.PointOfInterest
                .FirstOrDefault(c => c.CityId == CityId &&  c.Id == id);
        }

        public bool IsExist(int id)
        {
            return _cityInfocontext.PointOfInterest.Any(c => c.Id == id);
        }

        public void Addpointofinterest(int CityId, PointOfInterest pointOfInterest)
        {
            var getId = GetCity(CityId, false);
            getId.PointOfInterest.Add(pointOfInterest);
        }

        public void Updatepointofinterest(int CityId, PointOfInterest pointOfInterest)
        {

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _cityInfocontext.PointOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_cityInfocontext.SaveChanges() >= 0);
        }
    }
}
