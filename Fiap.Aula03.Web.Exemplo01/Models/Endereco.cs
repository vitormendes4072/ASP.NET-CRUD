﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Endereco")]
    public class Endereco
    {
        [Column("Id"), HiddenInput]
        public int EnderecoId { get; set; }
        [Required, MaxLength(100)]
        public string Logradouro { get; set; }
        [Required, MaxLength(10)]
        public string Cep { get; set; }
        public string Cidade { get; set; }
    }
}
