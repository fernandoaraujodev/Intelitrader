using GerenciandoUsuario.Dominio.Commands;
using GerenciandoUsuario.Dominio.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciandoUsuario.API.Controllers
{
    [Route("v1/conta")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [Route("create")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        // FromServices = definindo como serviço
        public GenericCommandResult CreateUser(CriarUsuarioCommand command, [FromServices]CriarUsuarioHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);

        }



    }
}