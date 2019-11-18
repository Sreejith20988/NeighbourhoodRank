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

namespace NeighbourhoodRank.Pages
{
    public class IndexModel : PageModel
    {
        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }

        public void OnGet()
        {
            using (var WebClient = new WebClient())
            {
                
                string jsonstring = GetData("https://data.cityofchicago.org/resource/xq83-jr8c.json");
 //               string jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/xq83-jr8c.json");
                QuickType.Energy[] energies = QuickType.Energy.FromJson(jsonstring);

                jsonstring = GetData("https://data.cityofchicago.org/resource/tfm3-3j95.json");
//                jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/tfm3-3j95.json");
                QuickTypeVehicle.Vehicle[] vehicles = QuickTypeVehicle.Vehicle.FromJson(jsonstring);

                List<Affluence> affluence = new List<Affluence>();

                var energy_query = from energy in energies
                                  group energy by new { energy.ZipCode, energy.Latitude, energy.Longitude } into g
                                  select new
                                  {
                                      Zip = g.Key.ZipCode,
                                      Latitude = Math.Round(g.Key.Latitude, 0),
                                      Longitude = Math.Round(g.Key.Longitude, 0),
                                      PowerUsage = Math.Round(g.Sum(u => u.ElectricityUseKbtu) / g.Sum(u => u.GrossFloorAreaBuildingsSqFt), 0)

                                      ////FloorSize = energy.GrossFloorAreaBuildingsSqFt,
                                      //TotalUsage = g.Sum(u=> u.ElectricityUseKbtu),

                                  };

                var vehicle_query = from vehicle in vehicles
                                    group vehicle by new { vehicle.ZipCode} into k
                                    select new
                                    {
                                        Zip = k.Key.ZipCode,
                                        vehicleCount = k.Count()
                            };

                var final_query = from energy in energy_query
                                  join vehicle in vehicle_query
                                  on energy.Zip equals vehicle.Zip
                                  select new
                                  {
                                      Zip = energy.Zip,
                                      Latitude = energy.Latitude,
                                      Longitude = energy.Longitude,
                                      PowerUsage = energy.PowerUsage,
                                      VehicleCount = vehicle.vehicleCount
                                  };

                List<Affluence> target = new List<Affluence>();

                foreach (var item in final_query)
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
                ViewData["affluence"] = affluence;
            }


        }
    }
}



