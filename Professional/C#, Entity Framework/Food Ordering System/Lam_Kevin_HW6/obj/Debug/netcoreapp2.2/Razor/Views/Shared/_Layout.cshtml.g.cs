#pragma checksum "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c210231115705d8aa795fd6fff22fae70f6482f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Lam_Kevin_HW6.Views.Shared.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Layout.cshtml", typeof(Lam_Kevin_HW6.Views.Shared.Views_Shared__Layout))]
namespace Lam_Kevin_HW6.Views.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/_ViewImports.cshtml"
using Lam_Kevin_HW6.Models;

#line default
#line hidden
#line 1 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c210231115705d8aa795fd6fff22fae70f6482f", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"497b00018005629001361ceb8e04ac17811f5b17", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/twitter-bootstrap/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/popper.js/popper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/twitter-bootstrap/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(95, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(122, 249, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c210231115705d8aa795fd6fff22fae70f6482f5389", async() => {
                BeginContext(128, 119, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>");
                EndContext();
                BeginContext(248, 13, false);
#line 9 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
                EndContext();
                BeginContext(261, 27, true);
                WriteLiteral(" - Food Truck</title>\r\n    ");
                EndContext();
                BeginContext(288, 74, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4c210231115705d8aa795fd6fff22fae70f6482f6258", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(362, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(371, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(373, 2167, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c210231115705d8aa795fd6fff22fae70f6482f8353", async() => {
                BeginContext(379, 540, true);
                WriteLiteral(@"
    <div>
        <nav class=""navbar navbar-expand-lg navbar-dark bg-primary"">
            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#nav-content"" aria-controls=""nav-content"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                <span class=""navbar-toggler-icon""></span>
            </button>
            <div class=""collapse navbar-collapse"" id=""nav-content"">
                <ul class=""navbar-nav mr-auto"">
                    <li class=""nav-item"">
                        ");
                EndContext();
                BeginContext(920, 75, false);
#line 21 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                   Write(Html.ActionLink("Home", "Index", "Home", null, new { @class = "nav-link" }));

#line default
#line hidden
                EndContext();
                BeginContext(995, 96, true);
                WriteLiteral("\r\n                    </li>\r\n                    <li class=\"nav-item\">\r\n                        ");
                EndContext();
                BeginContext(1092, 83, false);
#line 24 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                   Write(Html.ActionLink("Products", "Index", "Products", null, new { @class = "nav-link" }));

#line default
#line hidden
                EndContext();
                BeginContext(1175, 29, true);
                WriteLiteral("\r\n                    </li>\r\n");
                EndContext();
#line 26 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                     if (User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
                BeginContext(1284, 75, true);
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            ");
                EndContext();
                BeginContext(1360, 79, false);
#line 29 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                       Write(Html.ActionLink("Orders", "Index", "Orders", null, new { @class = "nav-link" }));

#line default
#line hidden
                EndContext();
                BeginContext(1439, 33, true);
                WriteLiteral("\r\n                        </li>\r\n");
                EndContext();
#line 32 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                         if (User.IsInRole("Admin"))
                        {

#line default
#line hidden
                BeginContext(1555, 83, true);
                WriteLiteral("                            <li class=\"nav-item\">\r\n                                ");
                EndContext();
                BeginContext(1639, 85, false);
#line 35 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                           Write(Html.ActionLink("Suppliers", "Index", "Suppliers", null, new { @class = "nav-link" }));

#line default
#line hidden
                EndContext();
                BeginContext(1724, 120, true);
                WriteLiteral("\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                ");
                EndContext();
                BeginContext(1845, 88, false);
#line 38 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                           Write(Html.ActionLink("Manage Users", "Index", "RoleAdmin", null, new { @class = "nav-link" }));

#line default
#line hidden
                EndContext();
                BeginContext(1933, 37, true);
                WriteLiteral("\r\n                            </li>\r\n");
                EndContext();
#line 40 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                        }

#line default
#line hidden
#line 40 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                         
                    }

#line default
#line hidden
                BeginContext(2020, 55, true);
                WriteLiteral("                </ul>\r\n            </div>\r\n            ");
                EndContext();
                BeginContext(2076, 40, false);
#line 44 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
       Write(await Html.PartialAsync("_LoginPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(2116, 82, true);
                WriteLiteral("\r\n        </nav>\r\n    </div>\r\n\r\n    <div class=\"container body-content\">\r\n        ");
                EndContext();
                BeginContext(2199, 12, false);
#line 49 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(2211, 58, true);
                WriteLiteral("\r\n        <hr />\r\n        <footer>\r\n            <p>&copy; ");
                EndContext();
                BeginContext(2270, 17, false);
#line 52 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Shared/_Layout.cshtml"
                 Write(DateTime.Now.Year);

#line default
#line hidden
                EndContext();
                BeginContext(2287, 66, true);
                WriteLiteral(" - BevoSoft Consultants</p>\r\n        </footer>\r\n    </div>\r\n\r\n    ");
                EndContext();
                BeginContext(2353, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c210231115705d8aa795fd6fff22fae70f6482f14326", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2403, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2409, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c210231115705d8aa795fd6fff22fae70f6482f15564", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2458, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2464, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c210231115705d8aa795fd6fff22fae70f6482f16802", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2531, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2540, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
