using GerenciandoUsuario.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GerenciandoUsuario.Testes
{
    public class UsuarioTestes
    {
        //Testes
        
        [Fact]
        public void UsuarioSemNome()
        {
            var usuario = new Usuario("", "Masculino");
            Assert.True(usuario.Invalid, "Usuário é válido");
        }
        
    }
}