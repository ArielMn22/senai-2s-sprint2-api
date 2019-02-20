using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        /// <returns>Retorna um Status Code</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}