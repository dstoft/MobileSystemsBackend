namespace MobileSystemsBackend.Domain
{
    public interface ITripRepository
    {
        int Create(Trip trip);
        Trip Read(int id);
    }
}