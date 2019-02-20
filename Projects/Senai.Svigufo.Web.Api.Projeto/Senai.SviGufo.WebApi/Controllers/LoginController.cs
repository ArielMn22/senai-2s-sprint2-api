using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using Senai.SviGufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; } // Declarando interface IUsuarioRepository;

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository(); // Poliformismo da Interface para o repositório UsuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                UsuarioDomain usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new
                        {
                            mensagem = "Usuário não encontrado...",
                        }    
                    );
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Svigufo.WebApi",
                    audience: "Svigufo.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch
            {
                return BadRequest(new
                    {
                        mensagem = "Deu Bug, aqui é possível deixar uma mensagem sobre o BadRequest."
                    }
                );
            }

        }
    }
}
