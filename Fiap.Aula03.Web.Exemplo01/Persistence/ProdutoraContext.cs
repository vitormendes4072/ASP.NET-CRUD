using Fiap.Aula03.Web.Exemplo01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01.Persistence
{
    public class ProdutoraContext : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }

        //Construtor que recebe DbContextOptions (string de conexão)
        public ProdutoraContext(DbContextOptions options) : base(options){ }
    }
}
