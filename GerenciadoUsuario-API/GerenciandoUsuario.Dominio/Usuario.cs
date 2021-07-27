using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace GerenciandoUsuario.Dominio
{
    public class Usuario : Notifiable
    {
        public Usuario(string nome, DateTime dataNascimento, string sexo)
        {
            // Validando dados com Flunt
            // https://medium.com/tableless/n%C3%A3o-lance-exceptions-em-seu-dom%C3%ADnio-use-notifications-70b31f7148d3
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 2, "Nome", "O nome deve ter no minimo 2 caracteres")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no maximo 40 caracteres")
                .IsNotNullOrEmpty(Sexo, "Sexo", "Informe o seu sexo")
                .IsNotNullOrEmpty(DataNascimento.ToString(), "DataNascimento", "Informe a sua data de nascimento")
            );

            if (Valid)
            {
                Id = Guid.NewGuid();
                Nome = nome;
                DataNascimento = dataNascimento;
                Sexo = sexo;
                DataCriacao = DateTime.Now;
                DataAlteracao = DateTime.Now;
            }
            
        }

        
        public Guid Id { get; private set; } 
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }


        public void AlterarUsuario()
        {

        }
        
    }
}
