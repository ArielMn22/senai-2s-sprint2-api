using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.DataBaseFirst.WebApi.Domains;

namespace Senai.InLock.DataBaseFirst.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EstudiosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarEstudios()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro:" + ex
                });
            }
        }

        // GET - api/estudios/estudiosComJogos
        [HttpGet("estudiosComJogos")]
        public IActionResult Get()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    //return Ok(ctx.Estudios.Include("Jogos").ToList());
                    return Ok(ctx.Estudios.Include(x => x.Jogos).ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro:" + ex
                });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    ctx.Estudios.Add(estudio);
                    ctx.SaveChanges();

                    return Ok();
                }
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