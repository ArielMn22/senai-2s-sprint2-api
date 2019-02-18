using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "A instituição deve possuir um CNPJ.")]
        public string CNPJ { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string UF{ get; set; }
        public string Cidade { get; set; }
    }
}
