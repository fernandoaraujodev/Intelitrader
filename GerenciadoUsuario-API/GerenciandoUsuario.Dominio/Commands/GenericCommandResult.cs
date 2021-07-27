using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandoUsuario.Dominio.Commands
{
    //Padronizando as respostas dos endpoints
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Data { private get; set; }
    }
}
