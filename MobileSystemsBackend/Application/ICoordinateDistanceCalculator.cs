using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Application
{
    public interface ICoordinateDistanceCalculator
    {
        double CalculateDistance(Coordinate coordinate1, Coordinate coordinate2);
    }
}