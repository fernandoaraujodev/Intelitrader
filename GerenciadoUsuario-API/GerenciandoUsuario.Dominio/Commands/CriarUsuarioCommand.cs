using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace GerenciandoUsuario.Dominio.Commands
{
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        //COMMAND = Definir as propriedades de entrada e suas validações, sem acesso externo

        //Construtor sem parametros
        public CriarUsuarioCommand()
        {

        }

        public CriarUsuarioCommand(string nome, DateTime dataNascimento, string sexo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }


        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 2, "Nome", "O nome deve ter no minimo 2 caracteres")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no maximo 40 caracteres")
                .IsNotNullOrEmpty(Sexo, "Sexo", "Informe o seu sexo")
                .IsNotNullOrEmpty(DataNascimento.ToString(), "DataNascimento", "Informe a sua data de nascimento")
            );
        }


    }
}
