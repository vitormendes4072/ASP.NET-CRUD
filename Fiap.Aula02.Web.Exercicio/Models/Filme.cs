using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exercicio.Models
{
    public class Filme
    {
        [HiddenInput]
        public int Codigo { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }
        [Display(Name = "Data de lançamento"), DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public string Produtora { get; set; }
        [Display(Name = "Livre para todas as idades")]
        public bool LivreTodasIdades { get; set; }
    }
}
