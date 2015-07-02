using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraspagApiDotNetSdk.Contracts.Antifraud
{
    public class TravelData
    {
        public string Route { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string JourneyType { get; set; }
        public List<TravelLegData> Legs { get; set; }
    }
}
