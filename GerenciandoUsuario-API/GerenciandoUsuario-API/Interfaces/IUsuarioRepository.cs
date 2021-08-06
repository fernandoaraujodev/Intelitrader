using GerenciandoUsuario_API.Domains;
using System;
using System.Collections.Generic;

namespace GerenciandoUsuario_API.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(Guid id);

        void Adicionar(Usuario usuario);

        void Editar(Guid id, Usuario usuario);

        void Remover(Guid id);
    }
}
