using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //com apicontroller nao precisa do frombody(tipo IformCollection)
    [ApiController]
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Arquitetura"},
            new TipoEventoDomain{ Id = 3, Nome = "Engenharia"},
            new TipoEventoDomain{ Id = 4, Nome = "Medicina"}
        };

        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }

        [HttpGet]
        //retorna uma lista de eventos
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Cadastrar(tipoEvento);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Alterar(tipoEvento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoEventoRepository.Deletar(id);
            return Ok();
        }

        //id em cima para acessar na url
        [HttpPut ("{id}")]
        public IActionResult PutById(int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// retorna um tipo de evento pelo id
        /// </summary>
        /// <param name="id">id do evento</param>
        /// <returns>tipoeventodomain</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //busca um tipo de evento pelo seu id
            TipoEventoDomain TipoEventoSerProcurado = tiposEventos.Find(x => x.Id == id);

            if(TipoEventoSerProcurado == null)
            {
                return NotFound();
            }
            return Ok(TipoEventoSerProcurado);
        }
    }
}