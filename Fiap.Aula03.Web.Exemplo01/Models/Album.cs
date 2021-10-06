using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    [Table("Tbl_Album")]
    public class Album
    {
        [Column("Id"), HiddenInput]
        public int AlbumId { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Column("Dt_Lancamento", TypeName = "Date"), DataType(DataType.Date), Display(Name = "Data Lançamento")]
        public DateTime DataLancamento { get; set; }

        //Relacionamento Um-Para-Muitos
        public IList<Musica> Musicas { get; set; }
    }
}