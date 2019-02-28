using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;

namespace Senai.InLock.DataBaseFirst.WebApi.Controllers
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
        public IActionResult Get()
        {
            try
            {
                return Ok(JogoRepository.ListarJogos());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost]
        public IActionResult Post(Jogos jogo)
        {
            try
            {
                JogoRepository.CadastrarJogo(jogo);

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

        [HttpPut]
        public IActionResult Put(Jogos jogo)
        {
            try
            {
                JogoRepository.AtualizarJogo(jogo);

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

        [HttpDelete]
        public IActionResult Delete(Jogos jogo)
        {
            try
            {
                JogoRepository.DeletarJogo(jogo);

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