using Senai.SviGufo.WebApi.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Senai.SviGufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }

        public EventoDomain Evento { get; set; }

        public UsuarioDomain Usuario { get; set; }

        // O número da situação, informa a sua descrição - 'texto'
        public EnSituacaoConvite Situacao { get; set; }
    }
}