using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    [Table("Estudios")]
    public class EstudioDomain
    {
        // Agora vai
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstudioId { get; set; }

        [Required]
        [Column("NomeEstudio", TypeName = "varchar(150)")]
        public string NomeEstudio { get; set; }

        //[Required]
        List<JogoDomain> Jogos { get; set; }
    }
}
