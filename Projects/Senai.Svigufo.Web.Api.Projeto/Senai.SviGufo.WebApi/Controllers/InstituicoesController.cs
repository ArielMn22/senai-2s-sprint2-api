using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as instituições cadastradas no sistema
        /// </summary>
        /// <returns>List<InsituicaoDomain></returns>
        [HttpGet]
        // Assunto de amanhã
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Get() => Ok(InstituicaoRepository.Listar()); ///Método feito com lambda, mas poderia ser feito instanciando uma lista e retornando a lista do método 'InstituicaoRepository.Listar()'

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id) => Ok(InstituicaoRepository.BuscarPorId(id));

        [HttpPost]
        public IActionResult Post(InstituicaoDomain instituicao)
        {
            try // Tenta executar a acao...
            {
                InstituicaoRepository.Cadastrar(instituicao);
                return Ok();
            }
            catch // Caso não consiga realizar a ação acima execute...
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(InstituicaoDomain instituicao)
        {
            InstituicaoRepository.Editar(instituicao);

            return Ok();
        }

        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna um status code.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            InstituicaoRepository.Excluir(id);

            return Ok();
        }

    }
}