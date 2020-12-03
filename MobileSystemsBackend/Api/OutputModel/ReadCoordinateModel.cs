namespace MobileSystemsBackend.Api.OutputModel
{
    public class ReadCoordinateModel
    {
        public int Id { get; set; }
        public long EpochTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int TripId { get; set; }
    }
}