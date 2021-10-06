using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Models
{
    //Mapeia a tabela associativa da relação M:N
    [Table("Tbl_Musica_Artista")]
    public class MusicaArtista
    {
        public int MusicaId { get; set; }
        public Musica Musica { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }
    }
}
