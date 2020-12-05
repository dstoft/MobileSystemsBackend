namespace MobileSystemsBackend.Api.OutputModel
{
    public class ReadTripStatsModel
    {
        public int TripId { get; set; }
        public double TotalSeconds { get; set; }
        public int CoordinateCount { get; set; }
        public double TotalMeters { get; set; }
        public double AvgSpeed { get; set; }
    }
}