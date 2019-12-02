using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighbourhoodRank
{
    public class Affluence : IComparable<Affluence>
    {
        public string Zip { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal PowerUsage { get; set; }
        public decimal VehicleCount { get; set; }

       

        public int CompareTo(Affluence obj)
        {
            if (this.PowerUsage.CompareTo(obj.PowerUsage) != 0)
                return this.PowerUsage.CompareTo(obj.PowerUsage);

            if (this.VehicleCount.CompareTo(obj.VehicleCount) != 0)
                return this.VehicleCount.CompareTo(obj.VehicleCount);

            return this.Zip.CompareTo(obj.Zip);

        }
    }
}
