using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        [Required(ErrorMessage = "Deve possuir um Id")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo de e-mail é necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é necessário.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A senha deve possui entre 3 e 100 catactéres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "É necessário o tipo de usuário.")]
        public string TipoUsuario { get; set; }
    }
}
