using GerenciandoUsuario.Dominio;
using Xunit;

namespace GerenciandoUsuario.Testes
{
    public class UsuarioTestes
    {
        //Testes
        
        [Fact]
        public void UsuarioSemNome()
        {
            //var usuario = new Usuario("", "02-09-2008", "Masculino");
            //Assert.True(usuario.Valid, "Usuário é inválido");
        }

        [Fact]
        public void UsuarioComNome()
        {
            //var usuario = new Usuario("Fernando Araujo", "", "Masculino");
            //Assert.True(usuario.Valid, "Usuário é inválido");
        }

    }
}