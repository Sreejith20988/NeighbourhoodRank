using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CafeSpace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace NeighbourhoodRank.Pages
{
    public class CafesChicagoModel : PageModel
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
            List<Cafe> cafes = new List<Cafe>();
            using (var WebClient = new WebClient())
            {
                string jsonstring = GetData("https://caferecords20191109053359.azurewebsites.net/JSONFeed");
                List<CafeSpace.Cafe> allCafe = CafeSpace.Cafe.FromJson(jsonstring);



                foreach (Cafe cafe in allCafe)
                {
                    cafes.Add(cafe);
                }
            }



            ViewData["cafes"] = cafes;
        }
    }
}