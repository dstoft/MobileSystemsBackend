using System.Collections.Generic;

namespace MobileSystemsBackend.Domain
{
    public interface ICoordinateRepository
    {
        int Create(Coordinate coordinate);
        List<int> CreateBulk(List<Coordinate> coordinate);
        List<Coordinate> ReadAll();
    }
}