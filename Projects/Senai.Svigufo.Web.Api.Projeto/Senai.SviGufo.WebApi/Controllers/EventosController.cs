﻿using System;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventosController : ControllerBase
    {
        private IEventoRepository EventoRepository { get; set; }

        public EventosController()
        {
            EventoRepository = new EventoRepository(); // Declarando repositório
        }

        /// <summary>
        /// Lista todos os eventoso
        /// </summary>
        /// <returns>Retorna Status Code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(EventoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                }
                );
            }
        }

        [HttpPost]
        public IActionResult Post(EventoDomain evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                }
                );
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EventoDomain evento)
        {
            try
            {
                EventoRepository.Atualizar(id, evento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}