#pragma checksum "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8198bfe706160d16b63b0ded630ae25186d31f58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Lam_Kevin_HW6.Views.Suppliers.Views_Suppliers_Details), @"mvc.1.0.view", @"/Views/Suppliers/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Suppliers/Details.cshtml", typeof(Lam_Kevin_HW6.Views.Suppliers.Views_Suppliers_Details))]
namespace Lam_Kevin_HW6.Views.Suppliers
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8198bfe706160d16b63b0ded630ae25186d31f58", @"/Views/Suppliers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"497b00018005629001361ceb8e04ac17811f5b17", @"/Views/_ViewImports.cshtml")]
    public class Views_Suppliers_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Lam_Kevin_HW6.Models.Supplier>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(83, 129, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Supplier</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(213, 48, false);
#line 14 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierName));

#line default
#line hidden
            EndContext();
            BeginContext(261, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(323, 44, false);
#line 17 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierName));

#line default
#line hidden
            EndContext();
            BeginContext(367, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(428, 49, false);
#line 20 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierEmail));

#line default
#line hidden
            EndContext();
            BeginContext(477, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(539, 45, false);
#line 23 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierEmail));

#line default
#line hidden
            EndContext();
            BeginContext(584, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(645, 55, false);
#line 26 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierPhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(700, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(762, 51, false);
#line 29 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierPhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(813, 118, true);
            WriteLiteral("\r\n        </dd>\r\n</div>\r\n<table class=\"table table-sm table-primary\">\r\n    <tr>\r\n        <th>Product</th>\r\n    </tr>\r\n");
            EndContext();
#line 36 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
     foreach (ProductSupplier cd in Model.ProductSuppliers)
    {

#line default
#line hidden
            BeginContext(999, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(1030, 52, false);
#line 39 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
           Write(Html.DisplayFor(modelItem => cd.Product.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(1082, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 41 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
    }

#line default
#line hidden
            BeginContext(1111, 17, true);
            WriteLiteral("</table>\r\n<div>\r\n");
            EndContext();
#line 44 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
     if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
    {

#line default
#line hidden
            BeginContext(1202, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(1210, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8198bfe706160d16b63b0ded630ae25186d31f588003", async() => {
                BeginContext(1264, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
                               WriteLiteral(Model.SupplierID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1272, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
#line 47 "/Users/kevinlam/Desktop/HW6/Lam_Kevin_HW6/Lam_Kevin_HW6/Views/Suppliers/Details.cshtml"
    }

#line default
#line hidden
            BeginContext(1295, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1299, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8198bfe706160d16b63b0ded630ae25186d31f5810551", async() => {
                BeginContext(1321, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1337, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Lam_Kevin_HW6.Models.Supplier> Html { get; private set; }
    }
}
#pragma warning restore 1591
