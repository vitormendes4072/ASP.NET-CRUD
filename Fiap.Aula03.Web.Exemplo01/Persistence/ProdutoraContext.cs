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
        //Construtor que recebe DbContextOptions (string de conexão)
        public ProdutoraContext(DbContextOptions options) : base(options){ }

        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<MusicaArtista> MusicaArtistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chava composta da tabela associativa
            modelBuilder.Entity<MusicaArtista>().HasKey(m => new { m.ArtistaId, m.MusicaId});

            //Configurar o relacionamento entre a tabela associativa e o artista
            modelBuilder.Entity<MusicaArtista>()
                .HasOne(m => m.Artista)
                .WithMany(m => m.MusicaArtistas)
                .HasForeignKey(m => m.ArtistaId);

            modelBuilder.Entity<MusicaArtista>().
                HasOne(m => m.Musica)
                .WithMany(m => m.MusicaArtistas)
                .HasForeignKey(m => m.MusicaId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
