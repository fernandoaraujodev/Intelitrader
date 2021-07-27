using Flunt.Notifications;
using GerenciandoUsuario.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandoUsuario.Infra.Data.Contexts
{
    public class GerenciandoUsuarioContext : DbContext
    {

        public GerenciandoUsuarioContext(DbContextOptions<GerenciandoUsuarioContext> options) : base(options)
        {

        }

        // Criando Tabela
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region TabelaUsuario

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            //Chave Primaria
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            //DataNascimento
            modelBuilder.Entity<Usuario>().Property(x => x.DataNascimento).HasColumnType("Date");
            modelBuilder.Entity<Usuario>().Property(x => x.DataNascimento).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Usuario>().Property(x => x.DataNascimento).IsRequired();
            //Sexo
            modelBuilder.Entity<Usuario>().Property(x => x.Sexo).HasColumnType("Text");
            modelBuilder.Entity<Usuario>().Property(x => x.Sexo).IsRequired();

            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao     
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
