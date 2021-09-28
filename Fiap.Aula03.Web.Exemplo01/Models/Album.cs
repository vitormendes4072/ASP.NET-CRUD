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
        [Column("Id")]
        public int AlbumId { get; set; }
        [Required, MaxLength(80)]
        public string Nome { get; set; }
        [DataType(DataType.Date), Display(Name = "Data de lançamento"), Column("Dt_Nascimento", TypeName = "date")]
        public DateTime DataLancamento { get; set; }
    }
}
