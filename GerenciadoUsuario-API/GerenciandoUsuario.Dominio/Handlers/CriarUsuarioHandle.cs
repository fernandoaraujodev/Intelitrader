using Flunt.Notifications;
using GerenciandoUsuario.Dominio.Commands;
using GerenciandoUsuario.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandoUsuario.Dominio.Handlers
{
    public class CriarUsuarioHandle : Notifiable, IHandler<CriarUsuarioCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }



        // Classe que vai manipular quando eu for criar um usuário
        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            //Fail Fast Validation
            //Válido
            command.Validar();
            //Não Válido
            if (command.Invalid)
                return new GenericCommandResult(false, "Informações do usuário inválidas", command.Notifications);

            //Salvar Usuario
            var usuario = new Usuario(command.Nome, command.DataNascimento, command.Sexo);
            if(usuario.Invalid)
                return new GenericCommandResult(false, "Informações do usuário inválidas", command.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            //Sucesso
            return new GenericCommandResult(true, "Usuario criado", usuario);
        }
    }
}
