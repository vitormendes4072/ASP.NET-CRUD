using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Artista")]
    public class Artista
    {
        [Column("Id")]
        public int ArtistaId { get; set; }
        [Required, MaxLength(80)]
        public string Nome { get; set; }
        [Display(Name = "Gênero")]
        public Genero? Genero { get; set; }
        [Display(Name = "Data de nascimento"), DataType(DataType.Date), Column("Dt_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        //One-to-One
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; } //FK da relação
    }
}

public enum GeneroArtista
{
    Masculino, Feminino, Outros
} 
