using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighbourhoodRank
{
    public class Affluence
    {
        public string ZipCode { get; set; }

        public string GrossFloorAreaBuildingsSqFt { get; set; }
        public string ElectricityUseKbtu { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int VehicleCount { get; set; }
    }
}
