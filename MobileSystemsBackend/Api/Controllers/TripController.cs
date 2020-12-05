using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.Mappers;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Application;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly ITripStatsBuilder _tripStatsBuilder;

        public TripController(ITripRepository tripRepository, ITripStatsBuilder tripStatsBuilder)
        {
            _tripRepository = tripRepository;
            _tripStatsBuilder = tripStatsBuilder;
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

        [HttpGet("{tripId}/stats")]
        public ActionResult<ReadTripStatsModel> Stats(int tripId)
        {
            return TripStatsMapper.MapFromDomain(_tripStatsBuilder.Build(tripId));
        }
    }
}