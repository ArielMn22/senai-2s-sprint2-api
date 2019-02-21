using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    /// <summary>
    /// Classe que representa os dados da tabela eventos.
    /// </summary>
    public class EventoDomain
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string  Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public bool AcessoLivre { get; set; }
        public TipoEventoDomain TipoEvento { get; set; }
        public int TipoEventoId { get; set; }
        public InstituicaoDomain Instituicao { get; set; }
        public int InstituicaoId { get; set; }
    }
}
