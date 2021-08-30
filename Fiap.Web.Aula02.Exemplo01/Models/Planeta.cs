using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Models
{
    /**
     * Criar uma página para cadastro -> Utilizando tag-Helpers
     * Controller -> private static IList<Planeta> _banco;
     * Criar uma página listar os planetas!
     */
    public class Planeta
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Nome { get; set; }

        //Renderizar um campo do tipo date
        [DataType(DataType.Date), Display(Name = "Data de Descoberta")]
        public DateTime DataDescoberta { get; set; }

        [Display(Name = "Habitável")]
        public bool Habitavel { get; set; }

        public TipoPlaneta Tipo { get; set; }

        public string Atmosfera { get; set; }

        [Display(Name = "Galáxia")]
        public string Galaxia { get; set; }

        [Display(Name = "Tempo de rotação")]
        public int TempoRotacao { get; set; }

    }

    public enum TipoPlaneta
    {
        Rochoso, Gasoso
    }
}
