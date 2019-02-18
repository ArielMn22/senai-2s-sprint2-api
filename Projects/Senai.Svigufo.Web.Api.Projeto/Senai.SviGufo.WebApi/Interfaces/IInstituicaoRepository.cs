using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        InstituicaoDomain BuscarPorId(int id);

        void Cadastrar(InstituicaoDomain instituicao);

        void Editar(InstituicaoDomain intituicao);

        void Excluir(int id);
    }
}
