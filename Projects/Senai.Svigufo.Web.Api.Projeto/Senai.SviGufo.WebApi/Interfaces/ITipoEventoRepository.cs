using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// lista todos os tipos de eventos
        /// </summary>
        /// <returns>retorna uma lista de tipo eventos</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// cadastra um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">objeto do tipo evento domain</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        void Deletar(int id);

        void Alterar(TipoEventoDomain tipoEvento);
    }
}
