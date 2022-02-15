using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.teste.Utils
{
    public class CriptografiaTests
    {
        [Fact] // Descrição
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            // Pré-condição / Arrange
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento / Act
            var retorno = regex.IsMatch(senha);

            // Resultado esperado / Assert 
            Assert.True(retorno);
        }
        [Fact]
        public void DeveRetornarComparacaoValida()
        {
            // Pré-Condição / Arrange
            var senha = "123456789";
            var hash = "$2a$11$r/KMTSbxevDeFcrT0Yi.6OhvK0BYAEiOhtb749JICDoQWskmZXKgu";

            // Procedimento / Act
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado esperado / Asserts
            Assert.True(comparacao);
        }
    }
}
