#pragma checksum "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd663a1fd7be27099bc4c1422e317ed8df5f5d4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeleteAccount_Delete), @"mvc.1.0.view", @"/Views/DeleteAccount/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd663a1fd7be27099bc4c1422e317ed8df5f5d4b", @"/Views/DeleteAccount/Delete.cshtml")]
    public class Views_DeleteAccount_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamsHelper.WebApp.ViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>\r\n    Delete account\r\n</h3>\r\n<p>\r\n    ");
#nullable restore
#line 12 "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml"
Write(Model.User.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 12 "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml"
                        Write(Model.User.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n</p>\r\n\r\n<br/>\r\n<br/>\r\n\r\n");
#nullable restore
#line 18 "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml"
 using (Html.BeginForm("ProceedDelete", "DeleteAccount", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" value=\"Submit\">\r\n");
#nullable restore
#line 21 "C:\Users\kacpe_v67r5jm\desktop\TeamsHelper\TeamsHelper.WebApp\Views\DeleteAccount\Delete.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamsHelper.WebApp.ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
