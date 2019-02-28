using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Interfaces
{
    public interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(int id);

        void Cadastrar(JogoDomain jogo);

        void Alterar(JogoDomain jogo);

        void Remover(JogoDomain jogo);
    }
}
