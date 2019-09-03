using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")] // Diz que todos os métodos retornaram um arquivo .json
    [Route("api/[controller]")]
    [ApiController] // Implementa funcionalidades no controller
    public class TiposEventosController : ControllerBase
    {
        //Declaração de um objeto List do tipo TipoEventoDomain
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia" },
            new TipoEventoDomain{ Id = 2, Nome = "Arquitetura" }
        };

        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Retorna uma string através do método Get()
        /// </summary>
        /// <returns>String</returns>
        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição recebida com sucesso!";
        //}

        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepository.Listar();
        }

        /// <summary>
        /// Retorna um tipo de evento pelo seu Id
        /// </summary>
        /// <param name="id">id do evento</param>
        /// <returns>TipoEventoDomain</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEventoSerProcurado = tiposEventos.Find(x => x.Id == id);

            if (tipoEventoSerProcurado == null)
            {
                return NotFound();
            }

            return Ok(tipoEventoSerProcurado);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento.
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Utilizado para alterar dados, por exemplo, o PUT possibilita enviar o Id do registro.
        /// 
        /// Atualiza o tipo de evento.
        /// </summary>
        /// <param name="tipoEvento">Tipo Evento a ser atualizado.</param>
        /// <returns>Retorna um status code.</returns>
        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Alterar(tipoEvento);

            return Ok();
        }

        /// <summary>
        /// Altera um tipo de evento passando o 'id' pela Url e o 'Nome' por meio do Body.
        /// </summary>
        /// <param name="id">Id do registro a ser alterado.</param>
        /// <param name="tipoEvento">Novo ome para o evento a ser alterado.</param>
        /// <returns></returns>
        [HttpPut("{id}")] // O '("{id}")' serve para dizer para o método que o id será recebido por meio da URL.
        public IActionResult Put(int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Deleta um registro.
        /// </summary>
        /// <param name="id">Recebe apenas o Id do registro.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoEventoRepository.Deletar(id);
            return Ok();
        }
    }
}