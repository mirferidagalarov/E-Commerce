#pragma checksum "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9107c92c219cc12faa5e2403440b2738ce9b4f5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SubscribeConfirm), @"mvc.1.0.view", @"/Views/Home/SubscribeConfirm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9107c92c219cc12faa5e2403440b2738ce9b4f5d", @"/Views/Home/SubscribeConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54cd8a0c02b885d4d4e222f1cba377fcef620c27", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_SubscribeConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
  
    var m = ViewBag.Message as Tuple<bool, string>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<nav class=""breadcrumb-nav"">
    <div class=""container"">
        <ul class=""breadcrumb"">
            <li><a href=""demo1.html""><i class=""d-icon-home""></i></a></li>
            <li>Contact Us</li>
        </ul>
    </div>
</nav>
<div class=""page-header"" style=""background-image: url(/uploads/images/page-header/contact-us.jpg)"">
    <h1 class=""page-title font-weight-bold text-capitalize ls-l"">Contact Us</h1>
</div>
<div class=""page-content mt-10 pt-7"">
    <section class=""contact-section"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-8 offset-2"">
");
#nullable restore
#line 24 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
                     if (m.Item1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-danger text-white\">\r\n\r\n                            ");
#nullable restore
#line 28 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
                       Write(m.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-success text-white\">\r\n                          \r\n                            ");
#nullable restore
#line 35 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
                       Write(m.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 37 "C:\Users\Lenovo\source\repos\E-commerce(.NET5)\E-commerce(.NET5)\Views\Home\SubscribeConfirm.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                   \r\n                    \r\n                 </div>\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n     </div>\r\n    </section>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
