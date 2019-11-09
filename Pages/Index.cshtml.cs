using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace NeighbourhoodRank.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (var WebClient = new WebClient())
            {
                string jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/xq83-jr8c.json");
                var energy = Energy.FromJson(jsonstring);
                ViewData["Energy"] = energy;

                jsonstring = WebClient.DownloadString("https://data.cityofchicago.org/resource/tfm3-3j95.json");
                var vehicles = QuickTypeVehicle.Vehicle.FromJson(jsonstring);
                ViewData["Vehicle"] = vehicles;
            }

        }
    }
}
