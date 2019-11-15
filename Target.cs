using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace NeighbourhoodRank
{
    public class Target
    {
        public string DataYear { get; set; }
        public string ZipCode { get; set; }
        public string FloorArea { get; set; }
        public string ElectricityUseKbtu { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
