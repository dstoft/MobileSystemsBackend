using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.Mappers;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Controllers
{
    [ApiController]
    [Route("api/Trip/{tripId}/[controller]")]
    public class CoordinateController : ControllerBase
    {
        private readonly ICoordinateRepository _coordinateRepository;

        public CoordinateController(ICoordinateRepository coordinateRepository)
        {
            _coordinateRepository = coordinateRepository;
        }

        [HttpGet]
        public ActionResult<List<ReadCoordinateModel>> List(int tripId)
        {
            var coordinateList = _coordinateRepository.ReadAll(tripId);
            var returnList = new List<ReadCoordinateModel>();
            coordinateList.ForEach(coordinate => returnList.Add(CoordinateMapper.MapFromDomain(coordinate)));
            return Ok(returnList);
        }

        // [HttpPost]
        // public ActionResult<Guid> Create([FromBody] CreateCoordinateModel createCoordinateModel, [FromRoute] int tripId)
        // {
        //     Console.WriteLine(
        //         $"Created coordinate: {createCoordinateModel.time}, {createCoordinateModel.latitude};{createCoordinateModel.longitude}");
        //     return Created("", Guid.NewGuid());
        // }

        [HttpPost]
        [Route("bulk")]
        public ActionResult<List<int>> CreateBulk([FromBody] List<CreateCoordinateModel> createCoordinateModels, [FromRoute] int tripId)
        {
            var coordinateList = new List<Coordinate>();
            createCoordinateModels.ForEach(model => coordinateList.Add(CoordinateMapper.MapToDomain(model, tripId)));
            _coordinateRepository.CreateBulk(coordinateList);
            return Created("", 0);
        }
    }
}