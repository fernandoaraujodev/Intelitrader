using GerenciandoUsuario.Dominio;
using GerenciandoUsuario.Dominio.Repositorios;
using GerenciandoUsuario.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciandoUsuario.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        //Injenção de dependência
        public readonly GerenciandoUsuarioContext _ctx;

        public UsuarioRepositorio(GerenciandoUsuarioContext ctx)
        {
            _ctx = ctx;
        }

        
        
        public void Adicionar(Usuario usuario)
        {
            _ctx.Usuarios.Add(usuario);
            _ctx.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _ctx.Entry(usuario).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _ctx.Usuarios.FirstOrDefault(p => p.Id == id);
        }

        public void Deletar(Guid id)
        {
            var usuario = BuscarPorId(id);
            _ctx
                .Usuarios
                .Remove(usuario);
            _ctx
                .SaveChanges();
        }

        public ICollection<Usuario> Listar()
        {
            return _ctx.Usuarios
                   .AsNoTracking()
                   .OrderBy(u => u.DataCriacao)
                   .ToList();
        }
    }
}
