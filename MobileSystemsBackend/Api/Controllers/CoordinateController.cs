using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinateController : ControllerBase
    {
        private readonly ICoordinateRepository _coordinateRepository;

        public CoordinateController(ICoordinateRepository coordinateRepository)
        {
            _coordinateRepository = coordinateRepository;
        }

        [HttpGet]
        public ActionResult<List<ReadCoordinateModel>> List()
        {
            var coordinateList = _coordinateRepository.ReadAll();
            var returnList = new List<ReadCoordinateModel>();
            coordinateList.ForEach(coordinate => returnList.Add(new ReadCoordinateModel
            {
                Id = coordinate.Id,
                EpochTime = coordinate.Time,
                Latitude = coordinate.Latitude,
                Longitude = coordinate.Longitude
            }));
//            var returnList = new List<ReadCoordinateModel>
//            {
//                new ReadCoordinateModel {EpochTime = 313, Id = Guid.NewGuid(), Latitude = 123.22, Longitude = 32.13},
//                new ReadCoordinateModel {EpochTime = 314, Id = Guid.NewGuid(), Latitude = 124.22, Longitude = 42.13}
//            };
            return Ok(returnList);
        }

        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreateCoordinateModel createCoordinateModel)
        {
            Console.WriteLine(
                $"Created coordinate: {createCoordinateModel.time}, {createCoordinateModel.latitude};{createCoordinateModel.longitude}");
            return Created("", Guid.NewGuid());
        }

        [HttpPost]
        [Route("bulk")]
        public ActionResult<List<Guid>> CreateBulk([FromBody] List<CreateCoordinateModel> createCoordinateModels)
        {
            createCoordinateModels.ForEach(model =>
                Console.WriteLine($"Created bulk coordinate: {model.time}, {model.latitude};{model.longitude}"));
            return Created("", Guid.NewGuid());
        }
    }
}