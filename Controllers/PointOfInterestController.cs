using AutoMapper;
using Cityinfo.API.Models;
using Cityinfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Cityinfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/PointOfInterest")]
    public class PointOfInterestController : ControllerBase
    {
        private readonly ILogger<PointOfInterestController> _ilogger;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointOfInterestController(ILogger<PointOfInterestController> ilogger, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _ilogger = ilogger ?? throw new ArgumentNullException(nameof(ilogger));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPointOfInterest(int cityId)
        {
            try
            {
               // throw new Exception("Exception example");

               var GetPoint = _cityInfoRepository.GetPointOfInterests(cityId);

                if (!_cityInfoRepository.IsExist(cityId))
                {
                    _ilogger.LogInformation($"No {cityId} found for this request");
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(GetPoint));
            }
            catch (Exception e)
            {
                _ilogger.LogCritical($"Exception while getting id with {cityId}", e);
                 return StatusCode(500, "A problem happened while loading request");
            }
        }

        [HttpGet("{id}" , Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterestById(int CityId, int id)
        {
            var GetPoint = _cityInfoRepository.GetPointOfInterest(CityId, id);

            if (!_cityInfoRepository.IsExist(CityId) && !_cityInfoRepository.IsExist(id))
            {
                _ilogger.LogInformation($"No Ids: {CityId} and {id} found for this request");
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(GetPoint));
        }

        [HttpPost]
        public IActionResult CreatePointofInterest(int cityId, [FromBody] CreatedPointOfInterest pointOfInterest)
        {

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError(
                 "Description",
                 "The Name and Description should not be same"
                    );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_cityInfoRepository.IsExist(cityId))
            {
                _ilogger.LogInformation($"The id : {cityId} does not exist");
                return NotFound();
            }


            var createPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);
            _cityInfoRepository.Addpointofinterest(cityId, createPointOfInterest);
            _cityInfoRepository.Save();

            var datatoreturn = _mapper.Map<PointOfInterestDto>(createPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new {cityId, id = datatoreturn.Id},
                datatoreturn);

        }

        [HttpPut("{id}")]
        public IActionResult CreatePointofInterest(int cityId, int id, [FromBody] UpdatePointOfInterest pointOfInterest)
        {
            try
            {
                if (pointOfInterest.Description == pointOfInterest.Name)
                {
                    ModelState.AddModelError(
                        "Description",
                        "The Name and description should not be the same"
                    );
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_cityInfoRepository.IsExist(id))
                {
                    _ilogger.LogInformation($"The id : {id} does not exist");
                    return NotFound();
                }


                var gettingtheID = _cityInfoRepository.GetPointOfInterest(cityId, id);
                if (gettingtheID == null)
                {
                    return NotFound();
                }


                _mapper.Map(pointOfInterest, gettingtheID);

                _cityInfoRepository
                    .Updatepointofinterest(cityId, gettingtheID);

                return NoContent();
            }
            catch (Exception e)
            {
                _ilogger.LogCritical($"Exception while getting id with {cityId}", e);
                return StatusCode(500, "A problem happened while loading request");
            }
        }

            [HttpPatch("{id}")]
        public IActionResult PatchPointofInterest(int cityId, int id, [FromBody] JsonPatchDocument<UpdatePointOfInterest> patchdocument)
        {
            //var city = CitiesDataStore.Current.Cities.FirstOrDefault(d => d.Id == cityId);
            //if (city == null)
            //{
            //    return NotFound();
            //}

            //var patchpointofinterest = city.PointOfInterest.FirstOrDefault(o => o.Id == id);
            //if (patchpointofinterest == null)
            //{
            //    return NotFound();
            //}

            //var patchdata = new UpdatePointOfInterest()
            //{
            //    Name = patchpointofinterest.Name,
            //    Description = patchpointofinterest.Description
            //};

            //patchdocument.ApplyTo(patchdata);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (patchdata.Description == patchdata.Name)
            //{
            //    ModelState.AddModelError(
            //        "Description",
            //        "Please ensure they are not the same value"
            //        );
            //}

            ////if (!TryValidateModel(patchdata))
            ////{
            ////    return BadRequest(ModelState);
            ////}

            //patchdata.Description = patchpointofinterest.Description;
            //patchdata.Name = patchpointofinterest.Name;

            //return NoContent();


            if (!_cityInfoRepository.IsExist(id))
            {
                _ilogger.LogInformation($"The id : {id} does not exist");
                return NotFound();
            }

            var gettingtheID = _cityInfoRepository.GetPointOfInterest(cityId, id);
            if (gettingtheID == null)
            {
                return NotFound();
            }

            var patchname = _mapper.Map<UpdatePointOfInterest>(gettingtheID);

            patchdocument.ApplyTo(patchname, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (patchname.Description == patchname.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "Please ensure they are not the same value"
                );

            }

            _mapper.Map(patchname, gettingtheID);

            _cityInfoRepository.Updatepointofinterest(cityId, gettingtheID);

            _cityInfoRepository.Save();

            return NoContent();



        }


        [HttpDelete("{id}")]

        public IActionResult DeletePointOfInterest(int id, int cityId)
        {
            //var city = CitiesDataStore.Current.Cities.FirstOrDefault(d => d.Id == cityId);
            //if (city == null)
            //{
            //    return NotFound();
            //}

            //var deletepointofinterest = city.PointOfInterest.FirstOrDefault(o => o.Id == id);
            //if (deletepointofinterest == null)
            //{
            //    return NotFound();
            //}

            //city.PointOfInterest.Remove(deletepointofinterest);
            //return NoContent();

            if (!_cityInfoRepository.IsExist(cityId))
            {
                return NotFound();
            }

            var IDtoDelete = _cityInfoRepository.GetPointOfInterest(cityId, id);
            if (IDtoDelete == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(IDtoDelete);

            _cityInfoRepository.Save();

            return NoContent();

        }
    }
}
