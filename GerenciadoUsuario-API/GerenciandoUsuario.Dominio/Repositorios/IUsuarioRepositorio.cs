using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandoUsuario.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {

        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorId(Guid id);
        void Deletar(Guid id);
        ICollection<Usuario> Listar();
        

    }
}
