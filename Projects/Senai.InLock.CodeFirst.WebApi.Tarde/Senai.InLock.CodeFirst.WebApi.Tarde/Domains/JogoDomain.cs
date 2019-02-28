using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    [Table("Jogos")]
    public class JogoDomain
    {
        [Key]
        [DataBaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int JogoId { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string NomeJogo { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required]
        // Gravação
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        //Leitura
        public EstudioDomain Estudio { get; set; }
    }
}
