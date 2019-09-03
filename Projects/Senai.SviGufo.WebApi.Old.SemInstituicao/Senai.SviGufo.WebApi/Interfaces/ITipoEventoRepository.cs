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
        /// Lista todos os tipos de eventos.
        /// </summary>
        /// <returns>Retorna uma lista com os tipos de evento.</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto de tipo evento domain</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">Id do registro a ser deletado.</param>
        void Deletar(int id);

        void Alterar(TipoEventoDomain tipoEvento);
    }
}