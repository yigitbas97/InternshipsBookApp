#pragma checksum "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceedd5b9e94b441ddc99495d52966a06534c9036"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Examine), @"mvc.1.0.view", @"/Views/Page/Examine.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Examine.cshtml", typeof(AspNetCore.Views_Page_Examine))]
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
#line 1 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\_ViewImports.cshtml"
using InternshipsBookApp;

#line default
#line hidden
#line 2 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\_ViewImports.cshtml"
using InternshipsBookApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceedd5b9e94b441ddc99495d52966a06534c9036", @"/Views/Page/Examine.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e47b8270bcf5b5b1ae9c8440f610c5b3ac6e0431", @"/Views/_ViewImports.cshtml")]
    public class Views_Page_Examine : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InternshipsBookApp.Models.PageExamineViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
  
    ViewData["Title"] = "Examine";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(146, 397, true);
            WriteLiteral(@"
<!--Text color for information-->
<style>
    h6 {
        color: black;
    }
</style>
<!--Selected Page Detail-->
<div class=""container mt-5 mb-5"" style=""border-color:black; border-style: dotted; border-width: 2px; background-color:white;"">
    <div class=""row"">
        <!--Book Information-->
        <div class=""col-md-6"" style=""padding: 15px;"">
            <h6>Staj Yeri      : ");
            EndContext();
            BeginContext(544, 26, false);
#line 18 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
                            Write(Model.Book.InternshipPlace);

#line default
#line hidden
            EndContext();
            BeginContext(570, 40, true);
            WriteLiteral("</h6>\r\n            <h6>Departman      : ");
            EndContext();
            BeginContext(611, 21, false);
#line 19 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
                            Write(Model.Book.Department);

#line default
#line hidden
            EndContext();
            BeginContext(632, 40, true);
            WriteLiteral("</h6>\r\n            <h6>Teslim Tarihi  : ");
            EndContext();
            BeginContext(673, 43, false);
#line 20 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
                            Write(Model.Book.DeliveryDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(716, 144, true);
            WriteLiteral("</h6>\r\n        </div>\r\n        <!--Page Information-->\r\n        <div class=\"col-md-6\" style=\"padding: 15px;\">\r\n            <h6>Sayfa Konusu   : ");
            EndContext();
            BeginContext(861, 13, false);
#line 24 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
                            Write(Model.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(874, 40, true);
            WriteLiteral("</h6>\r\n            <h6>Sayfa Numarası : ");
            EndContext();
            BeginContext(915, 12, false);
#line 25 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
                            Write(Model.Number);

#line default
#line hidden
            EndContext();
            BeginContext(927, 177, true);
            WriteLiteral("</h6>\r\n        </div>\r\n    </div>\r\n\r\n    <hr />\r\n    <!--Page Content-->\r\n    <div class=\"row\" style=\"color:black; padding:10px;\">\r\n        <div class=\"col-md-12\">\r\n            ");
            EndContext();
            BeginContext(1105, 27, false);
#line 33 "C:\Users\yiba_\Desktop\Yazılım Notlarım\Önemli Projeler\InternshipsBookApp\Views\Page\Examine.cshtml"
       Write(Html.Raw(Model.PageContent));

#line default
#line hidden
            EndContext();
            BeginContext(1132, 38, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InternshipsBookApp.Models.PageExamineViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
