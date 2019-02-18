using Microsoft.AspNetCore.Mvc;
using Senai.Produtos.WebAPI.Tarde.Domains;
using Senai.Produtos.WebAPI.Tarde.Interfaces;
using Senai.Produtos.WebAPI.Tarde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebAPI.Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository ProdutoRepository { get; set; }

        public ProdutosController()
        {
            ProdutoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Listar() => Ok(ProdutoRepository.Listar());

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Cadastrar(ProdutoDomain produto)
        {
            try
            {

                ProdutoRepository.Cadastrar(produto);
                return Ok();
            }
            catch
            {
                return BadRequest(
                        new
                        {
                            Mensagem = "Erro, BadRequest, insira os dados corretamente.",
                            erro = true
                        }
                    );
            }

        }
    }
}
