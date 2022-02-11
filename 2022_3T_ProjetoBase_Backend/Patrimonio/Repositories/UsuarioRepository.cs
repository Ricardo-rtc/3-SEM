using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if(usuario != null)
            {
                // Com o usuário encontrado, temos a hash do banco para podermo comarar com a senha vindo do formulário 
                if(usuario.Senha.Length < 32)
                {
                    usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                    ctx.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Criptografia.Comparar(senha, usuario.Senha);
                if (comparado)
                    return usuario;
            }

            return null;
        }
    }
}
