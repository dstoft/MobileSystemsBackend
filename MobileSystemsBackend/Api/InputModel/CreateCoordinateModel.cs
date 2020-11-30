using System;

namespace MobileSystemsBackend.Api.InputModel
{
    public class CreateCoordinateModel
    {
        // ReSharper disable once InconsistentNaming
        public long time { get; set; }
        // ReSharper disable once InconsistentNaming
        public double latitude { get; set; }
        // ReSharper disable once InconsistentNaming
        public double longitude { get; set; }
    }
}