#pragma checksum "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab4e2222b8fa0be269e066a0abbe073b88c507e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidate_Get), @"mvc.1.0.view", @"/Views/Candidate/Get.cshtml")]
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
#line 1 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\_ViewImports.cshtml"
using STUDENTEVOTINGAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\_ViewImports.cshtml"
using STUDENTEVOTINGAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab4e2222b8fa0be269e066a0abbe073b88c507e8", @"/Views/Candidate/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46e6ba9502abc26ba9e5031e9817a21651fa418d", @"/Views/_ViewImports.cshtml")]
    public class Views_Candidate_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<STUDENTEVOTINGAPP.DTOs.CandidateDto.CandidateDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Candidate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("<div>\r\n    <dl>\r\n        <dd>\r\n            ID\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 8 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml"
       Write(Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            FullName\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 14 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml"
       Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            MatricNum\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 20 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml"
       Write(Model.MatricNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            Election Name\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 26 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml"
       Write(Model.ElectionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            Position Name\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 32 "C:\Users\OLALEKAN\Desktop\MyFiles\Projects\STUDENTEVOTINGAPP\STUDENTEVOTINGAPP\Views\Candidate\Get.cshtml"
       Write(Model.PositionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n    </dl>\r\n</div>\r\n<div>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab4e2222b8fa0be269e066a0abbe073b88c507e85641", async() => {
                WriteLiteral("Back to Dashboard");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<STUDENTEVOTINGAPP.DTOs.CandidateDto.CandidateDto> Html { get; private set; }
    }
}
#pragma warning restore 1591