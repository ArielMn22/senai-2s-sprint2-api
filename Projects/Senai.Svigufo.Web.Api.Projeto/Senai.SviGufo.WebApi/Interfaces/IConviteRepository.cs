using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IConviteRepository
    {
        /// <summary>
        /// Lista todos os convites
        /// </summary>
        /// <returns>Retorna uma lista de ConviteDomain</returns>
        List<ConviteDomain> ListarTodos();

        /// <summary>
        /// Listar somente os comentarios do usuário
        /// </summary>
        /// <returns>Lista de ConviteDomain</returns>
        List<ConviteDomain> ListarMeusComentarios(int usuarioId);

        void InscreverConvite(ConviteDomain convite);
    }
}
