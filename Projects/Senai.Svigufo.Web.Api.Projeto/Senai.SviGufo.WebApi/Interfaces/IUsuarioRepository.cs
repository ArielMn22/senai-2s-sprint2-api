using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório usuário.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Busca um usuário por Email e Senha.
        /// </summary>
        /// <param name="email">email do usuário string</param>
        /// <param name="senha">senha do usuário string</param>
        /// <returns></returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
