using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Mappers
{
    public static class CoordinateMapper
    {
        public static Coordinate MapToDomain(CreateCoordinateModel createCoordinateModel, int tripId)
        {
            return new Coordinate
            {
                Time = createCoordinateModel.time,
                Latitude = createCoordinateModel.latitude,
                Longitude = createCoordinateModel.longitude,
                TripId = tripId
            };
        }

        public static ReadCoordinateModel MapFromDomain(Coordinate coordinate)
        {
            return new ReadCoordinateModel
            {
                Id = coordinate.Id,
                EpochTime = coordinate.Time,
                Latitude = coordinate.Latitude,
                Longitude = coordinate.Longitude,
                TripId = coordinate.TripId
            };
        }
    }
}