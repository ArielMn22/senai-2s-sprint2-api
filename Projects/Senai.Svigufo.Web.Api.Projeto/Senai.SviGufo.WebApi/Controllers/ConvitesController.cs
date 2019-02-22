using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    // O que ele produz?
    [Produces("application/json")] // JSON - JavaScript Object Notation
    [Route("api/[controller]")]
    [ApiController]
    public class ConvitesController : ControllerBase
    {
        private IConviteRepository ConviteRepository { get; set; }

        public ConvitesController()
        {
            ConviteRepository = new ConviteRepository();
        }

        [HttpGet]
        // Somente os administradores terão acesso a todos os convites
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(ConviteRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        mensagem = "Deu bug: " + ex
                    }
                    );
            }
        }

        [HttpGet]
        [Authorize]
        // Posso definir mais rotas para que dois métodos HttpGet possam existir juntos.
        [Route("meus")]
        // ====> /api/convites/meus
        public IActionResult MeusConvites()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(ConviteRepository.ListarMeusComentarios(usuarioId));
            } catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        mensagem = "Deu bug: " + ex
                    });
            }
        }

        [HttpPost("inscricao/{eventoid}")]
        // /api/convites/1
        [Authorize]
        public IActionResult Inscrever(int eventoId)
        {
            try
            {
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Deu ruim: " + ex
                });
            }
        }
    }
}