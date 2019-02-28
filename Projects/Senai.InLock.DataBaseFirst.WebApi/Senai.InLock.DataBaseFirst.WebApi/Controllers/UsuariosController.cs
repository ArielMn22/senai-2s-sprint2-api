using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;
using Senai.InLock.DataBaseFirst.WebApi.Repositories;

namespace Senai.InLock.DataBaseFirst.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
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
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);

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
        public IActionResult Put(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Atualizar(usuario);

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
        public IActionResult Delete(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Deletar(usuario);

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