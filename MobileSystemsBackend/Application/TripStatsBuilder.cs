using System.Linq;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Application
{
    public class TripStatsBuilder : ITripStatsBuilder
    {
        private readonly ICoordinateRepository _coordinateRepository;
        private readonly ICoordinateDistanceCalculator _coordinateDistanceCalculator;

        public TripStatsBuilder(ICoordinateRepository coordinateRepository, ICoordinateDistanceCalculator coordinateDistanceCalculator)
        {
            _coordinateRepository = coordinateRepository;
            _coordinateDistanceCalculator = coordinateDistanceCalculator;
        }
        
        public TripStats Build(int tripId)
        {
            var coordinates = _coordinateRepository.ReadAll(tripId);
            var coordinateCount = coordinates.Count;
            var totalSeconds = coordinates.Last().Time - coordinates.First().Time;
            var totalMeters = 0.0;
            Coordinate previousCoordinate = null;
            foreach (var coordinate in coordinates)
            {
                if (previousCoordinate == null)
                {
                    previousCoordinate = coordinate;
                    continue;
                }

                totalMeters += _coordinateDistanceCalculator.CalculateDistance(previousCoordinate, coordinate);
                previousCoordinate = coordinate;
            }

            var avgSpeed = totalMeters / totalSeconds;
            var avgSecondsPerCoordinate = totalSeconds / coordinateCount;
            return new TripStats
            {
                TripId = tripId,
                TotalSeconds = totalSeconds,
                CoordinateCount = coordinateCount,
                TotalMeters = totalMeters,
                AvgSpeed = avgSpeed,
                AvgSecondsPerCoordinate = avgSecondsPerCoordinate
            };
        }
    }
}