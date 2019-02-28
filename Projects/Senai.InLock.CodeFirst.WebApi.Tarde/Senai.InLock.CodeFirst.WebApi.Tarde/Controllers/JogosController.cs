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
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepository { get; set; }

        public JogosController()
        {
            JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(JogoRepository.Listar());
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
        public IActionResult Cadastrar(JogoDomain Jogo)
        {
            try
            {
                JogoRepository.Cadastrar(Jogo);

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
        public IActionResult Alterar(JogoDomain Jogo)
        {
            try
            {
                JogoDomain JogoProcurado = JogoRepository.BuscarPorId(Jogo.JogoId);

                if (JogoProcurado == null)
                {
                    return NotFound();
                }

                JogoRepository.Alterar(Jogo);

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
                JogoDomain JogoProcurado = JogoRepository.BuscarPorId(id);

                if (JogoProcurado == null)
                {
                    return NotFound();
                }

                JogoRepository.Remover(JogoProcurado);

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