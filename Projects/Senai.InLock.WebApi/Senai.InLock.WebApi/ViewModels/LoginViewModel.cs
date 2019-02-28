using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário um e-mail para efetuar o login.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessária uma senha para efetuar o login.")]
        public string Senha { get; set; }
    }
}
