#pragma checksum "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f31400c079ed4706f4bb07ae440d1acdb47afda8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Horarios_Index), @"mvc.1.0.view", @"/Views/Horarios/Index.cshtml")]
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
#line 1 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\_ViewImports.cshtml"
using UnitedCalendar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\_ViewImports.cshtml"
using UnitedCalendar.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
using UnitedCalendar.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f31400c079ed4706f4bb07ae440d1acdb47afda8", @"/Views/Horarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41941252fd4958a8153a1598c512677bf91bbf34", @"/Views/_ViewImports.cshtml")]
    public class Views_Horarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HorarioGestaoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdicionarCurso", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HorarioVisibilidade", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GerirDisciplinas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AtividadeExtras", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Gabinetes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Horário do ");
#nullable restore
#line 8 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
          Write(Model.User.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
 if (Model.User.CursoIdCurso == null) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f31400c079ed4706f4bb07ae440d1acdb47afda86020", async() => {
                WriteLiteral("Curso Pendente");
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
#nullable restore
#line 11 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                     WriteLiteral(Model.User.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
}else{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Curso: ");
#nullable restore
#line 13 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
          Write(Model.User.Curso.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 14 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
 if (Model.Horario.Publico) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Visibilidade: Publico</h3>\r\n");
#nullable restore
#line 18 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
}else{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Visibilidade: Privado</h3>\r\n");
#nullable restore
#line 20 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f31400c079ed4706f4bb07ae440d1acdb47afda89648", async() => {
                WriteLiteral("Mudar Visibilidade");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                      WriteLiteral(Model.Horario.IdHorario);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n<hr/>\r\n<h3>Disciplinas no Horário:</h3>\r\n");
#nullable restore
#line 24 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
 foreach (var item in Model.Disciplinas) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 25 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
          Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 25 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                       Write(item.DiaSemana);

#line default
#line hidden
#nullable disable
            WriteLiteral(": [");
#nullable restore
#line 25 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                         Write(item.HoraComeco);

#line default
#line hidden
#nullable disable
            WriteLiteral(" até ");
#nullable restore
#line 25 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                                              Write(item.HoraTermino);

#line default
#line hidden
#nullable disable
            WriteLiteral("]</p>\r\n");
#nullable restore
#line 26 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f31400c079ed4706f4bb07ae440d1acdb47afda813453", async() => {
                WriteLiteral("Gerir Disciplinas");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                   WriteLiteral(Model.Horario.IdHorario);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n<hr/>\r\n\r\n<h3>Atividades Extras no Horário:</h3>\r\n");
#nullable restore
#line 31 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
 foreach (var item in Model.AtividadeExtras) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 32 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
          Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 32 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                       Write(item.DiaSemana);

#line default
#line hidden
#nullable disable
            WriteLiteral(": [");
#nullable restore
#line 32 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                         Write(item.HoraComeco);

#line default
#line hidden
#nullable disable
            WriteLiteral(" até ");
#nullable restore
#line 32 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                                              Write(item.HoraTermino);

#line default
#line hidden
#nullable disable
            WriteLiteral("]</p>\r\n");
#nullable restore
#line 33 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f31400c079ed4706f4bb07ae440d1acdb47afda817269", async() => {
                WriteLiteral("Gerir Atividades Extras");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<hr/>\r\n\r\n");
#nullable restore
#line 37 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
 if (User.IsInRole("Professor"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Horarios de Gabinete no Horário:</h3>\r\n");
#nullable restore
#line 40 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
     foreach (var item in Model.Gabinetes) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 41 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
          Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 41 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                       Write(item.DiaSemana);

#line default
#line hidden
#nullable disable
            WriteLiteral(": [");
#nullable restore
#line 41 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                         Write(item.HoraComeco);

#line default
#line hidden
#nullable disable
            WriteLiteral(" até ");
#nullable restore
#line 41 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
                                                              Write(item.HoraTermino);

#line default
#line hidden
#nullable disable
            WriteLiteral("]</p>\r\n");
#nullable restore
#line 42 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f31400c079ed4706f4bb07ae440d1acdb47afda820560", async() => {
                WriteLiteral("Gerir Gabinetes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\FNAC\Documents\GitHub\TrabalhoGPS\UnitedCalendar\UnitedCalendar\Views\Horarios\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HorarioGestaoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
