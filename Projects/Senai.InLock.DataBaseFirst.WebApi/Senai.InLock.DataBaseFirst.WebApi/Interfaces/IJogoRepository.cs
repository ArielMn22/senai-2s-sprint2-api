using Senai.InLock.DataBaseFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogos> ListarJogos();

        void CadastrarJogo(Jogos jogo);

        void AtualizarJogo(Jogos jogo);

        void DeletarJogo(Jogos jogo);
    }
}
