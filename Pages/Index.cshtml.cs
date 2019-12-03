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
            Affluence affluence = new Affluence();
            IOrderedEnumerable<Affluence> rankedAffluence = affluence.AffluenceRank();

            ViewData["affluence"] = rankedAffluence;
        }
    }
}



