#pragma checksum "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d81c04b7c4a7fdcf3c6d500679d218e78e06f874"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NeighbourhoodRank.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(NeighbourhoodRank.Pages.Pages_Index), null)]
namespace NeighbourhoodRank.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\_ViewImports.cshtml"
using NeighbourhoodRank;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d81c04b7c4a7fdcf3c6d500679d218e78e06f874", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bea7e03515efb7e0f29e4b783bf36d03bdeb140e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
  

IOrderedEnumerable<Affluence> affluences = (IOrderedEnumerable<Affluence>)ViewData["affluence"];




#line default
#line hidden
            BeginContext(139, 345, true);
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <table class=""table"">
        <tr>
            <th>Rank</th>
            <th>Zip Code</th>
            <th>Latitude</th>
            <th>Longitude</th>
            <th>Points</th>
            <th>Power Usage</th>
            <th>Vehicle Count</th>
        </tr>

");
            EndContext();
#line 23 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
         foreach (NeighbourhoodRank.Affluence affluence in affluences)
        {

#line default
#line hidden
            BeginContext(567, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(606, 14, false);
#line 26 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.Rank);

#line default
#line hidden
            EndContext();
            BeginContext(620, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(648, 13, false);
#line 27 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.Zip);

#line default
#line hidden
            EndContext();
            BeginContext(661, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(689, 18, false);
#line 28 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(707, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(735, 19, false);
#line 29 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(754, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(782, 16, false);
#line 30 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.ACount);

#line default
#line hidden
            EndContext();
            BeginContext(798, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(826, 20, false);
#line 31 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.PowerUsage);

#line default
#line hidden
            EndContext();
            BeginContext(846, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(874, 22, false);
#line 32 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
               Write(affluence.VehicleCount);

#line default
#line hidden
            EndContext();
            BeginContext(896, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 34 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(933, 20, true);
            WriteLiteral("    </table>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
