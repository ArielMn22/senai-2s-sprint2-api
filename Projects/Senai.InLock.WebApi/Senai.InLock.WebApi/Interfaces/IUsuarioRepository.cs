using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um UsuarioDomain pelo email e senha.
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>retorna um UsuarioDomain caso o login seja válido.</returns>
        UsuarioDomain BuscarPorEmaileSenha(string email, string senha);
    }
}
