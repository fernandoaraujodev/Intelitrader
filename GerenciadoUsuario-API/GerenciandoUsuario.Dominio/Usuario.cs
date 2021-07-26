﻿using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace GerenciandoUsuario.Dominio
{
    public class Usuario : Notifiable
    {
        public Usuario(string nome, DateTime idade, string genero)
        {
            // Validando dados com Flunt
            // https://medium.com/tableless/n%C3%A3o-lance-exceptions-em-seu-dom%C3%ADnio-use-notifications-70b31f7148d3
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 2, "Nome", "O nome deve ter no minimo 2 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no maximo 40 caracteres")
                //TO DO: Validar idade

            );

            if (Valid)
            {
                Id = Guid.NewGuid();
                Nome = nome;
                //TO DO: fazer lógica para a idade
                Idade = DateTime.Parse("01/01/0001 00:00:00");
                Genero = genero;
                DataCriacao = DateTime.Now;
                DataAlteracao = DateTime.Now;
            }
            
        }

        
        public Guid Id { get; private set; } 
        public string Nome { get; private set; }
        public DateTime Idade { get; private set; }
        public string Genero { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        
    }
}