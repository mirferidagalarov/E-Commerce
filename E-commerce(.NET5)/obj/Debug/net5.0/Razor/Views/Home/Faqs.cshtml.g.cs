#pragma checksum "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86cbcb3fa65fe1f6ccc7c356200d8bea9620e073"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Faqs), @"mvc.1.0.view", @"/Views/Home/Faqs.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using E_commerce_.NET5_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using E_commerce_.NET5_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using E_commerce_.NET5_.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using E_commerce_.NET5_.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using E_commerce_.NET5_.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\_ViewImports.cshtml"
using Resource;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86cbcb3fa65fe1f6ccc7c356200d8bea9620e073", @"/Views/Home/Faqs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54cd8a0c02b885d4d4e222f1cba377fcef620c27", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Faqs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Faq>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
  
    ViewData["Title"] = "Faqs";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav class=""breadcrumb-nav"">
    <div class=""container"">
        <ul class=""breadcrumb"">
            <li><a href=""demo1.html""><i class=""d-icon-home""></i></a></li>
            <li>FAQs</li>
        </ul>
    </div>
</nav>
<div class=""page-header"" style=""background-image: url(/uploads/images/page-header/faq.jpg)"">
    <h3 class=""page-subtitle lh-1"">Frequently</h3>
    <h1 class=""page-title font-weight-bold text-capitalize lh-1"">Asked Questions</h1>
</div>
<div class=""page-content mb-10 pb-8"">
    <section>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12 mt-10"">

                    <div class=""accordion accordion-border accordion-boxed accordion-plus"">
");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"card\">\r\n                                <div class=\"card-header\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1023, "\"", 1049, 2);
            WriteAttributeValue("", 1030, "#collapse", 1030, 9, true);
#nullable restore
#line 29 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
WriteAttributeValue("", 1039, item.Id, 1039, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n                                        ");
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
                                   Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </a>\r\n                                </div>\r\n                                <div");
            BeginWriteAttribute("id", " id=\"", 1244, "\"", 1267, 2);
            WriteAttributeValue("", 1249, "collapse", 1249, 8, true);
#nullable restore
#line 33 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
WriteAttributeValue("", 1257, item.Id, 1257, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapsed\" style=\"display:none;\">\r\n                                    <div class=\"card-body\">\r\n                                        <p>\r\n                                            ");
#nullable restore
#line 36 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
                                       Write(item.Answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 41 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\Faqs.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                      \r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </section>\r\n\r\n\r\n</div>\r\n\r\n");
            DefineSection("addjs", async() => {
                WriteLiteral(@"
    <script>
         $(document).ready(function(){
             const relId=$('.accordion')
                   .find('.card:first-child a')
                   .removeClass('expand')
                   .addClass('collapse')
                   .attr('href');

                   $(`${relId}`)
                   .removeClass('collapsed')
                   .addClass('expanded')
                   .css('display','block');
         });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Faq>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
