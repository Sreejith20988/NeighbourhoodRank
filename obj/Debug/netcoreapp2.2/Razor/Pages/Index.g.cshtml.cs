#pragma checksum "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63ea1faffa74ed5536bbbe76a7ab01b076c658f7"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63ea1faffa74ed5536bbbe76a7ab01b076c658f7", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bea7e03515efb7e0f29e4b783bf36d03bdeb140e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";
    var energy_cons = (QuickType.Energy[]) ViewData["Energy"];

#line default
#line hidden
            BeginContext(135, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
 foreach(var item in energy_cons) {

#line default
#line hidden
            BeginContext(174, 22, true);
            WriteLiteral("    <tr>\r\n        <td>");
            EndContext();
            BeginContext(197, 12, false);
#line 10 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
       Write(item.ZipCode);

#line default
#line hidden
            EndContext();
            BeginContext(209, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 12 "C:\Users\Sreejith Nair\Google Drive\UC\Course\XML & Web Services\Project\NeighbourhoodRank\NeighbourhoodRank\Pages\Index.cshtml"
}

#line default
#line hidden
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
