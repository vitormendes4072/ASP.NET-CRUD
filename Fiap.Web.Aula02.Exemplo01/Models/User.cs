using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aula02.Exemplo01.Models
{
    public class User
    {
        public string Nome { get; set; }
        [Display(Name = "Data de nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        [HiddenInput]
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}\nData de nascimento: {DataNascimento}\nEmail: {Email}";
        }
    }
}
