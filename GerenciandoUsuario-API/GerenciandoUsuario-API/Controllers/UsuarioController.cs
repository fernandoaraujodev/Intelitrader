using GerenciandoUsuario_API.Domains;
using GerenciandoUsuario_API.Interfaces;
using GerenciandoUsuario_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciandoUsuario_API.Controllers
{
    [Route("v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        
        }


        #region Leitura

        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os usuários</returns>
        [HttpGet]
        public IActionResult GetUser()
        {

            if (!ModelState.IsValid)
            {
                //statusCode400
                return BadRequest(ModelState);
            }
            else
            {

                var usuario = _usuarioRepository.Listar();

                if (usuario.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    //statusCode 200
                    return Ok(usuario);
                }
            }

        }

        /// <summary>
        /// Busca o usuário com o id passado
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Objeto usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {

            if (!ModelState.IsValid)
            {
                //statusCode400
                return BadRequest(ModelState);
            }
            else
            {
                // Objeto do tipo usuário que recebe um objeto do método BuscarPorId 
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                // Se o objeto estiver nulo retorna NoContent 
                if (usuario == null)
                {
                    return NoContent();
                }
                else
                {
                    //statusCode200
                    return Ok(usuario);
                }
            }

        }
        #endregion

        #region Gravacao
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        [HttpPost]
        public IActionResult CreateUser([FromBody] Usuario usuario)
        {
            try
            {
                //Validando o modelo
                if (!ModelState.IsValid)
                {
                    //statusCode400
                    return BadRequest(ModelState);
                }

                //Adiciona um novo usuário
                _usuarioRepository.Adicionar(usuario);

                //statusCode 200
                return Ok(usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, usuario);
            }


        }



        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id">Id do usuario que será alterada</param>
        /// <param name="usuario">Dados do usuário que serão alterados</param>
        [HttpPut("{id}")]
        public IActionResult PutUser(Guid id, [FromBody] Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                //statusCode400
                return BadRequest(ModelState);
            }
            else
            {
                _usuarioRepository.Editar(id, usuario);

                //statusCode 200
                return Ok(usuario);
            }

        }


        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {

            if (!ModelState.IsValid)
            {
                //statusCode400
                return BadRequest(ModelState);
            }
            else
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
                };
            }

        }

        /*
        //TO DO:
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
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
        */
    }
    #endregion

}
