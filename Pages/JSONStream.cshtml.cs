using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeighbourhoodRank.Pages
{
    public class JSONStreamModel : PageModel
    {

       // public Affluence Affluence { get; set; }

        private IList<Affluence> aff = new List<Affluence>();

        public JsonResult OnGet(string passedObject)
        {
            IndexModel instance = new IndexModel();
            aff = instance.Getfinalval();
            return new JsonResult(aff);
        }
    }
}