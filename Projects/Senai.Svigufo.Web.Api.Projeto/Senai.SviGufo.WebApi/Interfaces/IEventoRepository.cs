using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Lista todos os eventos cadastrados.
        /// </summary>
        /// <returns>Retorna uma lista</returns>
        List<EventoDomain> Listar();

        /// <summary>
        /// Cadastra um evento no programa
        /// </summary>
        /// <param name="evento"></param>
        void Cadastrar(EventoDomain evento);

        /// <summary>
        /// Atualiza um evento.
        /// </summary>
        /// <param name="evento">EventoDomain</param>
        void Atualizar(int id, EventoDomain evento);
    }
}
