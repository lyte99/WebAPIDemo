#pragma checksum "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8a7847dda392775a44eea81923f1870937d5bb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AFElementSearch), @"mvc.1.0.view", @"/Views/Home/AFElementSearch.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AFElementSearch.cshtml", typeof(AspNetCore.Views_Home_AFElementSearch))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\_ViewImports.cshtml"
using WebApiClassV2;

#line default
#line hidden
#line 2 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\_ViewImports.cshtml"
using WebApiClassV2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8a7847dda392775a44eea81923f1870937d5bb3", @"/Views/Home/AFElementSearch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ca2a54850cf60253f676b33c02df3c7c55b9065", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AFElementSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApiClassV2.Models.AFElementSearchResults.RootObject>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
  
    ViewData["Title"] = "AFSearch";

#line default
#line hidden
            BeginContext(107, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
 if (Model == null)
{

#line default
#line hidden
            BeginContext(135, 105, true);
            WriteLiteral("    <h2 style=\"text-align:center\">AF Element Search</h2>\r\n    <br /><br />\r\n    <div class=\"container\">\r\n");
            EndContext();
#line 12 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
         using (Html.BeginForm())
        {

#line default
#line hidden
            BeginContext(286, 271, true);
            WriteLiteral(@"            <div class=""row"">
                <div class=""col-md-offset-4"">
                    <label class=""control-label col-md-2"" style=""text-align:right"">Search Query: (try ""network"")</label>
                    <span class=""col-md-2"">

                        ");
            EndContext();
            BeginContext(558, 27, false);
#line 19 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
                   Write(Html.TextBox("searchEntry"));

#line default
#line hidden
            EndContext();
            BeginContext(585, 227, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-2 col-md-offset-5\">\r\n                <input type=\"submit\" value=\"Submit\" class=\"btn btn-primary\" />\r\n            </div>\r\n");
            EndContext();
#line 26 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
        }

#line default
#line hidden
            BeginContext(823, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 28 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(847, 73, true);
            WriteLiteral("    <h2 style=\"text-align:center\">Search Results</h2>\r\n    <br /><br />\r\n");
            EndContext();
            BeginContext(924, 226, true);
            WriteLiteral("    <table class=\"table table-condensed table-striped\" align=\"center\" style=\"width:25%\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">Elements</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 41 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
             foreach (var item in Model.Items)
            {

#line default
#line hidden
            BeginContext(1213, 84, true);
            WriteLiteral("                <tr>\r\n                    <td scope=\"col\">\r\n                        ");
            EndContext();
            BeginContext(1298, 81, false);
#line 45 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
                   Write(Html.ActionLink(item.Name, "AttributeView", null, new { elementID = item.WebId }));

#line default
#line hidden
            EndContext();
            BeginContext(1379, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 48 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
            }

#line default
#line hidden
            BeginContext(1446, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 51 "C:\Users\aegelhof\source\repos\WebApiClassV2\WebApiClassV2\Views\Home\AFElementSearch.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApiClassV2.Models.AFElementSearchResults.RootObject> Html { get; private set; }
    }
}
#pragma warning restore 1591
