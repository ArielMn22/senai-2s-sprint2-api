using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using Senai.InLock.CodeFirst.WebApi.Tarde.Interfaces;
using Senai.InLock.CodeFirst.WebApi.Tarde.Repositories;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository EstudioRepository { get; set; }

        public EstudiosController()
        {
            EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(EstudioRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(EstudioDomain estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                });
            }
        }

        [HttpPut]
        public IActionResult Alterar(EstudioDomain estudio)
        {
            try
            {
                EstudioDomain estudioProcurado = EstudioRepository.BuscarPorId(estudio.EstudioId);

                if (estudioProcurado == null)
                {
                    return NotFound();
                }

                EstudioRepository.Alterar(estudio);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                EstudioDomain estudioProcurado = EstudioRepository.BuscarPorId(id);

                if (estudioProcurado == null)
                {
                    return NotFound();
                }

                EstudioRepository.Remover(estudioProcurado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}