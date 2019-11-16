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

                Affluence target = new Affluence();

                foreach(var item in query)
                {
                    target.Zip = item.Zip;
                    target.Record = item.Record;
                    target.FloorSize = item.FloorSize;
                    target.PowerUsage = item.PowerUsage;
                    target.TotalUsage = item.TotalUsage;
                    target.Latitude = item.Latitude;
                    target.Longitude = item.Longitude;

                    affluence.Add(target);
                }
                ViewData["affluence"] = affluence;
                }

               
            }
        }
    }
 


