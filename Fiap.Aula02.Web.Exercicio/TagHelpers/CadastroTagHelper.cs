using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exercicio.TagHelpers
{
    public class CadastroTagHelper : TagHelper
    {
        public string Texto { get; set; }
        public string Class { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "btn btn-primary" : Class);
            output.Attributes.SetAttribute("value", string.IsNullOrEmpty(Texto) ? "Cadastrar" : Texto);
        }
    }
}
