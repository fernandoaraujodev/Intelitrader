using GerenciandoUsuario_API.Domains;
using GerenciandoUsuario_API.Interfaces;
using GerenciandoUsuario_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciandoUsuario_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult CreateUser([FromBody] Usuario usuario)
        {
            try
            { 
                //Adiciona um novo usuário
                _usuarioRepository.Adicionar(usuario);

                //statusCode 200
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os usuários</returns>
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var usuario = _usuarioRepository.Listar();

                if (usuario.Count == 0)
                    return NoContent();

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id">Id do usuario que será alterada</param>
        /// <param name="usuario">Dados do usuário que serão alterados</param>
        // PUT api/<UsuarioController>/334E9136-6C38-4C1C-9B8D-54D193976C84
        [HttpPut("{id}")]
        public IActionResult PutUser(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Editar(id, usuario);


                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Busca o usuário com o id passado
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Objeto usuário</returns>
        // GET api/<UsuarioController>/334E9136-6C38-4C1C-9B8D-54D193976C84
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                // Objeto do tipo usuário que recebe um objeto do método BuscarPorId 
                Usuario user = _usuarioRepository.BuscarPorId(id);

                // Se o objeto estiver nulo retorna NoContent 
                if (user == null)
                {
                    return NoContent();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a mensagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        // DELETE api/<UsuarioController>/334E9136-6C38-4C1C-9B8D-54D193976C84
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario == null)
                {
                    return NoContent();
                }
                else
                {
                    //Passa o id do usuario que será excluído
                    _usuarioRepository.Remover(id);

                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        //TO DO:sexo colocar como enum

               mudar range de data de nascimento
                public class CustomDateAttribute : RangeAttribute
                {
                  public CustomDateAttribute()
                    : base(typeof(DateTime), 
                            DateTime.Now.AddYears(01-01-2013).ToShortDateString(),
                            DateTime.Now.ToShortDateString()) 
                  { } 
                }
                https://stackoverflow.com/questions/17321948/is-there-a-rangeattribute-for-datetime

                como retornar internal server error aspnetcore

                ajustar a instancia do controller
        */
    }
}
