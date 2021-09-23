using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Web.Aula02.Exemplo01.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        public string Texto { get; set; }
        public string Class { get; set; }
        //<botao texto="" class=""></botao>
        //<input type="submit" value="Cadastrar" class="btn btn-primary"
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag
            output.TagName = "input";
            //Definir os atributos da tag: type, value e class
            output.Attributes.SetAttribute("type", "submit");
           
            //Verifica se o texto está null ou vazio
            if (string.IsNullOrEmpty(Texto))
            {
                output.Attributes.SetAttribute("value", "Cadastrar");
            }
            else
            {
                output.Attributes.SetAttribute("value", Texto);
            }
            
            //Ternário...??
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "btn btn-primary" : Class);
        }
    }
}
