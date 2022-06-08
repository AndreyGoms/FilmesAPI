using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt):base(opt) {  }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.cinema)
                .WithOne(cinema => cinema.endereco)
                .HasForeignKey<Cinema>(cinema => cinema.enderecoId);
            //entidade do tipo endereco tem um cinema, logo ese cinema possui um endereco
            //acheve estrangeira esta em cinema e é o enderecoId

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.gerenteID);
            //  .OnDelete(DeleteBehavior.Restrict); faz com que a delecao seja restrita, ou seja, se deletar gerente o cinema ainda existiria
            // .HasForeignKey(cinema => cinema.gerenteID).IsRequired(false); possibilita criar cinema sem necessidade de uma chave de gerente

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.cinema)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);
        }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
