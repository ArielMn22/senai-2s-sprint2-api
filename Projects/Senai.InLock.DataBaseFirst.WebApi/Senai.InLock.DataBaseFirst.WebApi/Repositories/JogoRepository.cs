using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi
{
    public class JogoRepository : IJogoRepository
    {
        public void AtualizarJogo(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public void CadastrarJogo(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void DeletarJogo(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }

        public List<Jogos> ListarJogos()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }
    }
}
