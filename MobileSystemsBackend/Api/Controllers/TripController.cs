using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.Mappers;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;

        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        [HttpGet]
        public ActionResult<List<ReadTripModel>> List()
        {
            var tripList = _tripRepository.List();
            var returnList = new List<ReadTripModel>();
            tripList.ForEach(trip => returnList.Add(TripMapper.MapFromDomain(trip)));
            return Ok(returnList);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] CreateTripModel createTripModel)
        {
            var trip = TripMapper.MapToDomain(createTripModel);
            var tripId = _tripRepository.Create(trip);
            return Created("", tripId);
        }
    }
}