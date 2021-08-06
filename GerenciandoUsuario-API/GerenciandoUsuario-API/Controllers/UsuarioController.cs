using GerenciandoUsuario_API.Domains;
using GerenciandoUsuario_API.Interfaces;
using GerenciandoUsuario_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GerenciandoUsuario_API.Controllers
{
    [Route("v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger _logger;
        public string Message { get; set; }

        private readonly Guid _instanceId = Guid.NewGuid();

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;

            _logger.LogInformation($"Repo Instanceid{_instanceId}. Info: Repositório criado com sucesso");

        }

        protected void Logs(Exception ex)
        {
            _logger.LogInformation($"Houve um erro: {ex.Message}.");
            System.Console.WriteLine($"Houve um erro: {ex.Message}.");
        }


        #region Leitura

        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os usuários</returns>
        [HttpGet]
        public IActionResult GetUser()
        {

            _logger.LogInformation($"Listagem de usuários realizada");
            System.Console.WriteLine($"Listagem de usuários realizada");

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
                    return Ok(new
                    {
                        Total  = usuario.Count,
                        Data = usuario
                    });
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

                _logger.LogInformation($"Repo Instanceid{_instanceId}. Info: usuário criado com sucesso");

                //statusCode 200
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                Logs(ex);

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

            try
            {
                if (!ModelState.IsValid)
                {
                    //statusCode400
                    return BadRequest(ModelState);
                }

                _usuarioRepository.Editar(id, usuario);

                _logger.LogInformation($"O usuário {id} foi alterado");
                System.Console.WriteLine($"O usuário {id} foi alterado");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Logs(ex);

                return StatusCode(StatusCodes.Status500InternalServerError, usuario);

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

                    _logger.LogInformation($"O usuário {id} foi removido");
                    System.Console.WriteLine($"O usuário {id} foi removido");

                    return Ok(usuario);
                };

            }
            catch (Exception ex)
            {
                Logs(ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
    #endregion

}
