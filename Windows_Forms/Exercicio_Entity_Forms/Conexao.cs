using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Exercicio_Entity_Forms
{
    public class Conexao : DbContext
    {
        public DbSet<Maquina> Maquinas {get;set;}
        public DbSet<Software> Softwares {get;set;}
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Aula7;Username=postgres;Password=010206");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maquina>().ToTable("maquina");
            modelBuilder.Entity<Software>().ToTable("software");
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");
        }
    }
}