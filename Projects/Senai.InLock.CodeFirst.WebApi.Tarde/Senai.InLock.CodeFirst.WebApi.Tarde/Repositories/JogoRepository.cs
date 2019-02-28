using Senai.InLock.CodeFirst.WebApi.Tarde.Contexts;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using Senai.InLock.CodeFirst.WebApi.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public void Alterar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Find(id);
            }
        }

        public void Cadastrar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Remover(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }

        public List<JogoDomain> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }
    }
}
