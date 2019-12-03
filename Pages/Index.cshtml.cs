using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EnergySpace;
using VehicleSpace;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NeighbourhoodRank;

namespace NeighbourhoodRank.Pages
{
    public class IndexModel : PageModel
    {
        /*        public string GetData(string endpoint)
                {
                    string downloadedData = "";
                    using (WebClient webClient = new WebClient())
                    {
                        downloadedData = webClient.DownloadString(endpoint);
                    }
                    return downloadedData;
                }*/

        // THE 'BindProperty' Search will receive the value from the form
        // Note: The name attribute of the input in the HTML matches this name
        [BindProperty]
        public string Search { get; set; }

        // WE WILL USE THIS PROPERTY TO TRACK IF A SEARCH HAS BEEN PERFORMED
        public bool SearchCompleted { get; set; }

        // WE WILL STORE THE RESULTS IN THIS PROPERTY
        public Affluence SearchResults { get; set; }


        public void OnGet()
        {
            SearchCompleted = false;

            Affluence affluence = new Affluence();

            IOrderedEnumerable<Affluence> rankedAffluence = affluence.AffluenceRank();

            ViewData["affluence"] = rankedAffluence;
        }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search))
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                return;
            }
            Affluence affluence = new Affluence();

            IOrderedEnumerable<Affluence> rankedAffluence = affluence.AffluenceRank();

            List<Affluence> affluences = rankedAffluence.ToList();

            SearchResults = affluences.Find(x => x.Zip == Search);

            SearchCompleted = true;

        }


    }
}



