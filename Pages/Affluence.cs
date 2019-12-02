using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using QuickTypeVehicle;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NeighbourhoodRank;

namespace NeighbourhoodRank
{
    public class Affluence
    {
        public string Zip { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal PowerUsage { get; set; }
        public decimal VehicleCount { get; set; }
        public decimal ACount { get; set; }
        public decimal Rank { get; set; }

        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }

        public IOrderedEnumerable<Affluence> AffluenceRank()
        {
            using (var WebClient = new WebClient())
            {

                string jsonstring = GetData("https://data.cityofchicago.org/resource/xq83-jr8c.json");
                QuickType.Energy[] energies = QuickType.Energy.FromJson(jsonstring);

                jsonstring = GetData("https://data.cityofchicago.org/resource/tfm3-3j95.json");

                QuickTypeVehicle.Vehicle[] vehicles = QuickTypeVehicle.Vehicle.FromJson(jsonstring);

                List<Affluence> affluence = new List<Affluence>();

                var energyQuery = from energy in energies
                                  group energy by new { energy.ZipCode, energy.Latitude, energy.Longitude } into energyGroup
                                  select new
                                  {
                                      Zip = energyGroup.Key.ZipCode,
                                      Latitude = Math.Round(energyGroup.Key.Latitude, 0),
                                      Longitude = Math.Round(energyGroup.Key.Longitude, 0),
                                      PowerUsage = Math.Round(energyGroup.Sum(u => u.ElectricityUseKbtu) / energyGroup.Sum(u => u.GrossFloorAreaBuildingsSqFt), 0)
                                  };

                var vehicleQuery = from vehicle in vehicles
                                   group vehicle by new { vehicle.ZipCode } into vehicleGroup
                                   select new
                                   {
                                       Zip = vehicleGroup.Key.ZipCode,
                                       vehicleCount = vehicleGroup.Count()
                                   };

                var finalQuery = from energy in energyQuery
                                 join vehicle in vehicleQuery
                                 on energy.Zip equals vehicle.Zip

                                 select new
                                 {
                                     Zip = energy.Zip,
                                     Latitude = energy.Latitude,
                                     Longitude = energy.Longitude,
                                     PowerUsage = energy.PowerUsage,
                                     VehicleCount = vehicle.vehicleCount
                                 };

                foreach (var item in finalQuery)
                {
                    affluence.Add(new Affluence
                    {
                        Zip = item.Zip,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        PowerUsage = item.PowerUsage,
                        VehicleCount = item.VehicleCount
                    });
                }

                var PowerRank = affluence.Sum(a => a.PowerUsage);
                var VehicleRank = affluence.Sum(a => a.VehicleCount);

                foreach (var item in affluence)
                {
                    item.ACount = ((item.PowerUsage / (PowerRank / 100)) + (item.VehicleCount / (VehicleRank / 100))) * 100;
                    item.ACount = Math.Round(item.ACount, 2);
                }

                var rankedAffluence = affluence.OrderByDescending(a => a.ACount);

                var rank = 1;
                foreach (var item in rankedAffluence)
                {
                    item.Rank = rank;
                    rank++;
                }

                return rankedAffluence;
            }

        }
    }
}
