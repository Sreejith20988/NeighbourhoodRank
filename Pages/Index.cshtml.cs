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
        public void OnGet()
        {
            using (var WebClient = new WebClient())
            {
                /*               IDictionary<long, QuickType.Energy> allEnergy = new Dictionary<long, QuickType.Energy>();
                */

                string jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/xq83-jr8c.json");
                QuickType.Energy[] energies = QuickType.Energy.FromJson(jsonstring);
                
                jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/tfm3-3j95.json");
                QuickTypeVehicle.Vehicle[] vehicles = QuickTypeVehicle.Vehicle.FromJson(jsonstring);

               List<Affluence> affluence = new List<Affluence>();

                var query = from energy in energies
                            join vehicle in vehicles
                            on energy.ZipCode equals vehicle.ZipCode
                            select new
                            {
                                Zip = energy.ZipCode,
                                Record = vehicle.RecordId,
                                FloorSize = energy.GrossFloorAreaBuildingsSqFt,
                                TotalUsage = energy.ElectricityUseKbtu,
                                PowerUsage = energy.ElectricityUseKbtu / energy.GrossFloorAreaBuildingsSqFt,
                                Latitude = energy.Latitude,
                                Longitude = energy.Longitude
                            };

                List<Affluence> target = new List<Affluence>();

                foreach(var item in query)
                {


                    affluence.Add(new Affluence
                    { Zip = item.Zip,
                        Record = item.Record,
                        FloorSize = item.FloorSize,
                        TotalUsage = item.TotalUsage,
                        PowerUsage = item.PowerUsage,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude });
                }
                ViewData["affluence"] = affluence;
                }

               
            }
        }
    }
 


