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
        //private IList<Affluence> affluence = new List<Affluence>();

        public JsonResult OnGet(string passedObject)
        {
            Affluence instanceAffluence = new Affluence();
            IOrderedEnumerable<Affluence> affluence = instanceAffluence.AffluenceRank();
            return new JsonResult(affluence);
        }
    }
}