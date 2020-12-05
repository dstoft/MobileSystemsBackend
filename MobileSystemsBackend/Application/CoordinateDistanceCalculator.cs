using System;
using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Application
{
    public class CoordinateDistanceCalculator : ICoordinateDistanceCalculator
    {
        // https://www.movable-type.co.uk/scripts/latlong.html
        public double CalculateDistance(Coordinate coordinate1, Coordinate coordinate2)
        {
            var R = 6371000;
            var phiOne = coordinate1.Latitude * Math.PI / 180;
            var phiTwo = coordinate2.Latitude * Math.PI / 180;
            var deltaPhi = (coordinate2.Latitude - coordinate1.Latitude) * Math.PI / 180;
            var deltaLambda = (coordinate2.Longitude - coordinate1.Longitude) * Math.PI / 180;

            var a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                    Math.Cos(phiOne) * Math.Cos(phiTwo) * Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = R * c;
            return distance;
        }
    }
}