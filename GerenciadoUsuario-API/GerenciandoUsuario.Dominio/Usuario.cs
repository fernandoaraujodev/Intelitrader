using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace GerenciandoUsuario.Dominio
{
    public class Usuario : Notifiable
    {
        public Usuario(string nome, string genero)
        {
            // Validando dados com Flunt
            // https://medium.com/tableless/n%C3%A3o-lance-exceptions-em-seu-dom%C3%ADnio-use-notifications-70b31f7148d3
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 2, "Nome", "O nome deve ter no minimo 2 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no maximo 40 caracteres")
                // Validar idade
            );


            Id = Guid.NewGuid();
            Nome = nome;
            Idade = DateTime.Now;
            Genero = genero;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;

        }

        
        public Guid Id { get; private set; } 
        public string Nome { get; private set; }
        public DateTime Idade { get; private set; }
        public string Genero { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        
    }
}
