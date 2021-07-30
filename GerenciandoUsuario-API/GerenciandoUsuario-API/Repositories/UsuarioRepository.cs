using GerenciandoUsuario_API.Contexts;
using GerenciandoUsuario_API.Domains;
using GerenciandoUsuario_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciandoUsuario_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciandoUsuarioContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new GerenciandoUsuarioContext();
        }

        //Implementando a interface
        #region Leitura
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuarios.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuarios.OrderBy(o => o.DataCriacao).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravacao
        public void Adicionar(Usuario usuario)
        {
            // O contexto recebe o objeto inst do método
            _ctx.Add(usuario);

            //Salva as alterações no banco de dados Edux
            _ctx.SaveChanges();
        }

        public void Editar(Guid id, Usuario usuario)
        {
            
            // BuscarPorId para verificar a existência do usuário informado
            Usuario usuarioTemp = BuscarPorId(id);

            //Se ela não existir é informado que o usuário não foi encontrado
            if (usuarioTemp == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            else
            {
                 //Caso contrário salva todas as alterações no objeto usuarioTemp
                 usuarioTemp.Nome = usuario.Nome;
                 usuarioTemp.DataNascimento = usuario.DataNascimento;
                 usuarioTemp.Sexo = usuario.Sexo;
                 usuarioTemp.DataAlteracao = usuario.DataAlteracao;


                 //Atualiza com o id informado
                 _ctx.Usuarios.Update(usuarioTemp);

                 //Salva as alterações no contexto
                 _ctx.SaveChanges();
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                //Usa o método BuscarPorId para verificar a existência da instituição informada
                Usuario usuarioTemp = BuscarPorId(id);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (usuarioTemp == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                else
                {
                    //Remove a instituição informada do contexto
                    _ctx.Usuarios.Remove(usuarioTemp);

                    //Salva todas as alterações
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}