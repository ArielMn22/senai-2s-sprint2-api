using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")] // Diz que todos os métodos retornaram um arquivo .json
    [Route("api/[controller]")]
    //[ApiController]
    public class TiposEventosController : ControllerBase
    {
        //Declaração de um objeto List do tipo TipoEventoDomain
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Arquitetura"}
        };

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
            return tiposEventos;
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
    }
}