using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.teste.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {
            // Pré-condição / Arrange
            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();


            var controller = new LoginController(fakerepository.Object);

            // Procedimento / Act
            var resultado = controller.Login(loginViewModel);

            // Resultado esperado / Assert 
            Assert.IsType<UnauthorizedObjectResult>(resultado);


        }
        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            // Pré-condição / Arrange
            var usuarioFake = new Usuario();
            usuarioFake.Email = "paulo@email.com";
            usuarioFake.Senha = "$2a$11$4fbpy.mM9Rzf5qc6MJC0t..QduYte8kRBDzjHb9Y0DYlCa4cXLhaa";

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();


            var controller = new LoginController(fakerepository.Object);
            loginViewModel.Email = "paulo@email.com";
            loginViewModel.Senha = "123456789";

            // Procedimento / Act
            var resultado = controller.Login(loginViewModel);

            // Resultado esperado / Assert 
            Assert.IsType<OkObjectResult>(resultado);


        }
    }
}
