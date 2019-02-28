using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;
using Senai.InLock.DataBaseFirst.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // Retorna um usuário que corresponda com o login.email e login.senha
                return ctx.Usuarios.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
