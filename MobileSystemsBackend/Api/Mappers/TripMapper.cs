using MobileSystemsBackend.Api.InputModel;
using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Mappers
{
    public static class TripMapper
    {
        public static Trip MapToDomain(CreateTripModel createTripModel)
        {
            return new Trip {Time = createTripModel.Time};
        }

        public static ReadTripModel MapFromDomain(Trip trip)
        {
            return new ReadTripModel {Id = trip.Id, Time = trip.Time};
        }
    }
}