using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    public class ScreenSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<MusicasArtista> MusicasArtistas { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<GenerosMusica> GenerosMusica { get; set; }



        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicasArtista>()
                .HasKey(ma => new { ma.ArtistaId, ma.MusicaId });

            modelBuilder.Entity<MusicasArtista>()
                .HasOne(ma => ma.Artista)
                .WithMany(a => a.MusicasArtistas)
                //.WithMany()
                .HasForeignKey(ma => ma.ArtistaId);

            modelBuilder.Entity<MusicasArtista>()
                .HasOne(ma => ma.Musica)
                .WithMany(m => m.MusicasArtistas)
                //.WithMany()
                .HasForeignKey(ma => ma.MusicaId);


            modelBuilder.Entity<GenerosMusica>()
    .HasKey(gm => new { gm.MusicaId, gm.GeneroId });

            modelBuilder.Entity<GenerosMusica>()
                .HasOne(gm => gm.Musica)
                .WithMany(m => m.GenerosMusicas)
                .HasForeignKey(gm => gm.MusicaId);

            modelBuilder.Entity<GenerosMusica>()
                .HasOne(gm => gm.Genero)
                .WithMany(g => g.GenerosMusicas)
                .HasForeignKey(gm => gm.GeneroId);

        }




    }
}
