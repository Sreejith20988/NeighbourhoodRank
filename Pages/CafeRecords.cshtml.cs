using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighbourhoodRank;
using System.Net;

namespace NeighbourhoodRank.Pages
{
    public class CafeRecordsModel : PageModel
    {
        public void OnGet()
        {


            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString("https://caferecords20191109053359.azurewebsites.net/JSONFeed");
                NeighbourhoodRank.Cafe[] cafes = NeighbourhoodRank.Cafe.FromJson(downloadedData);
                ViewData["cafe"] = cafes;
            }
            
        }
    }
}