using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Interfaces
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);

        void Cadastrar(EstudioDomain estudio);

        void Alterar(EstudioDomain estudio);

        void Remover(EstudioDomain estudio);
    }
}
