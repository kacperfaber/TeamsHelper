#pragma checksum "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e4db70fca6bb0b530ef60abafa093d66a336767"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Setup_Setup), @"mvc.1.0.view", @"/Views/Setup/Setup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e4db70fca6bb0b530ef60abafa093d66a336767", @"/Views/Setup/Setup.cshtml")]
    public class Views_Setup_Setup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamsHelper.WebApp.SetupViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>title</h2>\r\n\r\n<div>\r\n    <span>Microsoft Account</span>\r\n    <br/>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
     if (Model.MicrosoftValidation == null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
   Write(Html.ActionLink("Authorize", "AuthorizeMicrosoft", "OAuth"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
                                                                    
    }

    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
   Write(await Html.PartialAsync("_TokenValidationView", Model.MicrosoftValidation));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
                                                                                   
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br/>\r\n</div>\r\n\r\n<div>\r\n    <span>Google Account</span>\r\n    <br/>\r\n\r\n");
#nullable restore
#line 30 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
         if (Model.GoogleValidation== null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
       Write(Html.ActionLink("Authorize", "AuthorizeGoogle", "OAuth"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
                                                                     
        }
    
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
       Write(await Html.PartialAsync("_TokenValidationView", Model.GoogleValidation));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\Setup\Setup.cshtml"
                                                                                    
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <br/>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamsHelper.WebApp.SetupViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
