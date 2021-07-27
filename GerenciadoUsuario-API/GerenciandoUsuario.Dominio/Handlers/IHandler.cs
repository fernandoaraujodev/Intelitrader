using GerenciandoUsuario.Dominio.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandoUsuario.Dominio.Handlers
{
    // Definindo assinatura 
    // Ao herdar o IHandler deve ser pasado uma classe que herda o ICommand
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T commnad);
    }
}
