using System.Collections.Generic;

namespace MobileSystemsBackend.Domain
{
    public interface ICoordinateRepository
    {
        int Create(Coordinate coordinate);
        int CreateBulk(List<Coordinate> coordinates);
        List<Coordinate> ReadAll();
        List<Coordinate> ReadAll(int tripId);
    }
}