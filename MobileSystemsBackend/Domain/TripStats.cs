namespace MobileSystemsBackend.Domain
{
    public class TripStats
    {
        public int TripId { get; set; }
        public double TotalSeconds { get; set; }
        public int CoordinateCount { get; set; }
        public double TotalMeters { get; set; }
        public double AvgSpeed { get; set; }
    }
}