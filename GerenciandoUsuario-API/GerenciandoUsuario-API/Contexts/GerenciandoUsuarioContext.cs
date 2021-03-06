using GerenciandoUsuario_API.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GerenciandoUsuario_API.Contexts
{
    public class GerenciandoUsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }


        // String de conexão com o banco
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }


        // Modelando o DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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
