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
        }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
