using Senai.InLock.CodeFirst.WebApi.Tarde.Contexts;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using Senai.InLock.CodeFirst.WebApi.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        public void Alterar(EstudioDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Update(estudio);
                ctx.SaveChanges();
            }
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Find(id);
            }
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public List<EstudioDomain> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();
            }
        }

        public void Remover(EstudioDomain estudio)
        {

            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }
    }
}
