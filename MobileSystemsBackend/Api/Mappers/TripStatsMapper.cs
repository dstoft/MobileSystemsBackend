using MobileSystemsBackend.Api.OutputModel;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Api.Mappers
{
    public static class TripStatsMapper
    {
        public static ReadTripStatsModel MapFromDomain(TripStats tripStats)
        {
            return new ReadTripStatsModel
            {
                TripId = tripStats.TripId,
                TotalSeconds = tripStats.TotalSeconds,
                CoordinateCount = tripStats.CoordinateCount,
                TotalMeters = tripStats.TotalMeters,
                AvgSpeed = tripStats.AvgSpeed,
                AvgSecondsPerCoordinate = tripStats.AvgSecondsPerCoordinate
            };
        }
    }
}