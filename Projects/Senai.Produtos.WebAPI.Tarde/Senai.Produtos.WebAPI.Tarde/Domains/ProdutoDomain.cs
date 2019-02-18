using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebAPI.Tarde.Domains
{
    public class ProdutoDomain
    {
        public int Id { get; set; }

        [
            Required(ErrorMessage = "É necessário um campo nome para cadastrar um produto."), 
            StringLength(150, ErrorMessage = "O nome do produto não pode ser maior que 150 caractéres."), 
            MinLength(3, ErrorMessage = "O nome do produto não pode ser menor que 3 caractéres.")
        ]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário uma descrição para cadastrar um produto.")]
        public string Descricao { get; set; }
    }
}
