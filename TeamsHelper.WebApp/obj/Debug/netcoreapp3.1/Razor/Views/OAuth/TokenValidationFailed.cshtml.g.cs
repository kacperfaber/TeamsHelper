#pragma checksum "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "200b8a8e3175a28fb16e948efd821fd6b896458d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OAuth_TokenValidationFailed), @"mvc.1.0.view", @"/Views/OAuth/TokenValidationFailed.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"200b8a8e3175a28fb16e948efd821fd6b896458d", @"/Views/OAuth/TokenValidationFailed.cshtml")]
    public class Views_OAuth_TokenValidationFailed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamsHelper.WebApp.TokenValidationFailedViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Token Validation Failed</h2>\r\n\r\n<div>\r\n    Access Token: ");
#nullable restore
#line 11 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml"
             Write(Model.Token.AccessToken);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br>\r\n    Refresh Token: ");
#nullable restore
#line 13 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml"
              Write(Model.Token.RefreshToken);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br>\r\n    Token Type: ");
#nullable restore
#line 15 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml"
           Write(Model.Token.TokenType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    <br/>\r\n    <br/>\r\n\r\n    ");
#nullable restore
#line 20 "C:\Users\kacpe_v67r5jm\Desktop\TeamsHelper\TeamsHelper.WebApp\Views\OAuth\TokenValidationFailed.cshtml"
Write(Html.ActionLink("Back home", "AuthorizedHome", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamsHelper.WebApp.TokenValidationFailedViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
