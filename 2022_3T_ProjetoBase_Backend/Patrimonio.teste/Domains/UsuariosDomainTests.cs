using Patrimonio.Domains;
using Patrimonio.Utils;
using Xunit;

namespace Patrimonio.teste.Domains
{
    public class UsuariosDomainTests
    {
        [Fact] // Descrição
        public void Deve_Retornar_Usuario_Prenchido()
        {
            // Pré-condição / Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";

            // Procedimento / Act
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            // Resultado esperado / Assert 
            Assert.True(resultado);                                                                             
        }

        [Fact]
        public void DeveRetornarComparacaoValida()
        {
            // Pré-condição / Arrange
            var senha = "123456789";
            var hash = "$2a$11$4fbpy.mM9Rzf5qc6MJC0t..QduYte8kRBDzjHb9Y0DYlCa4cXLhaa";

            // Procedimento / Act
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado esperado / Assert 
            Assert.True(comparacao);
        }
    }
}
