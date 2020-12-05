using MobileSystemsBackend.Domain;

namespace MobileSystemsBackend.Application
{
    public interface ITripStatsBuilder
    {
        TripStats Build(int tripId);
    }
}