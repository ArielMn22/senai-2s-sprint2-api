using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> ListarUsuarios();

        void Cadastrar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        void Deletar(Usuarios usuario);

        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
