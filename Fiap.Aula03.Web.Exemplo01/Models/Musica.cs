using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Musica")] //Nome da tabela
    public class Musica
    {
        [Column("Id"), HiddenInput] //Nome da coluna
        public int MusicaId { get; set; }
        [Required, MaxLength(80)] //Obrigatório, Tamanho máximo de caractéres
        public string Nome { get; set; }
        [DataType(DataType.Date), Display(Name = "Data de Lançamento"), Column("Dt_Lancamento", TypeName = "date"), Required]
        public DateTime DataLancamento { get; set; }
        [Display(Name = "Duração")]
        public float? Duracao { get; set; }
        [Display(Name = "Explícita")]
        public bool Explicita { get; set; }
        [Display(Name = "Gênero")]
        public Genero? Genero { get; set; }
    }
}

public enum Genero
{
    Rock,
    Pop,
    Pagode,
    Samba,
    Mpb,
    Funk,
    Sertanejo,
    Trap,
    Rap
}
