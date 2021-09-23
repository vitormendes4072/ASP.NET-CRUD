using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        //<mensagem texto = ""> </mensagem>
        //<div class = "alert alert-sucess">texto</div>
        public string Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Validar se a div deve existir
            if (!string.IsNullOrEmpty(Texto))
            {
                //Definir o nome da tag
                output.TagName = "div";

                //Definir o class
                output.Attributes.SetAttribute("class", "alert alert-success");

                //Definir o conteúdo
                output.Content.SetContent(Texto);
            }
        }
    }
}
