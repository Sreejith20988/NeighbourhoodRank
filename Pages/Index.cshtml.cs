using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

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
                ViewData["Energy"] = energies;
                List<string> ZipCode = new List<string>();
                decimal cons;

                jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/tfm3-3j95.json");
                QuickTypeVehicle.Vehicle[] vehicles = QuickTypeVehicle.Vehicle.FromJson(jsonstring);
                ViewData["Vehicle"] = vehicles;

                foreach(QuickType.Energy energy in energies)
                {
                   
                    ZipCode.Add(energy.ZipCode);
/*                    cons = Decimal.Parse(energy.ElectricityUseKbtu);
*/ 
                }
            }

        }
    }
}
