using AutoMapper;
using Cityinfo.API.Models;
using Cityinfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cityinfo.API
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityinfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityinfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cityentities = _cityinfoRepository.GetCities();
            //var results = new List<CityWithoutPointOfInterestDto>();
            //foreach (var cityentity in cityentities)
            //{
            //    results.Add(
            //        new CityWithoutPointOfInterestDto()

            //        {
            //            Id = cityentity.Id,
            //            Name = cityentity.Name,
            //            Country = cityentity.Country,
            //            Description = cityentity.Description

            //        });

            //}
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityentities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includepointofinterest = false)
        {
            var getCityFirst = _cityinfoRepository.GetCity(id, includepointofinterest);

            if (getCityFirst == null)
            {
                return NotFound();
            }

            if (includepointofinterest)
            { 
            //{
            //    var includepot = new CitiesDto()
            //    {
            //        Id = getCityFirst.Id,
            //        Name = getCityFirst.Name,
            //        Country = getCityFirst.Country,
            //        Description = getCityFirst.Description
            //    };

            //    foreach (var p in includepot.PointOfInterest)
            //    {
            //        includepot.PointOfInterest.Add(
            //            new PointOfInterestDto()
            //            {
            //                Id = p.Id,
            //                Name = p.Name,
            //                Description = p.Description
            //            });
            //    }
                return Ok(_mapper.Map<CitiesDto>(getCityFirst));
            }

            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(getCityFirst));

        }
    }
}
