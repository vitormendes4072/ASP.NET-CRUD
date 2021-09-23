using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        [Display(Name = "CPF")]
        public long Cpf { get; set; }
        [HiddenInput]
        public int Id { get; set; }
    }
}
