using System.Collections.Generic;

namespace WTechAuth.Models
{
    //public class EmissionsData
    //{
    //    public string UserId { get; set; }
    //    public List<EmissionEntry> Entries { get; set; } // Renamed property
    //}

    //public class EmissionEntry
    //{
    //    public string Category { get; set; }
    //    public decimal Result { get; set; }
    //}
    public class EmissionsDatum
    {
        public string category { get; set; }
        public double result { get; set; }
    }

    public class Root
    {
        public int userId { get; set; }
        public List<EmissionsDatum> emissionsData { get; set; }
    }
}
