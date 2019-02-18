using Senai.Produtos.WebAPI.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebAPI.Tarde.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoDomain> Listar();

        void Cadastrar(ProdutoDomain produto);
    }
}
