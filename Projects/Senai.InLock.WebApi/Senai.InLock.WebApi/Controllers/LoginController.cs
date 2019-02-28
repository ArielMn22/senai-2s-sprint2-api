using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                UsuarioDomain loginUsuario = UsuarioRepository.BuscarPorEmaileSenha(login.Email, login.Senha);

                if (loginUsuario == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Usuário não encontrado."
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, loginUsuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, loginUsuario.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, loginUsuario.TipoUsuario)
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
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro ocorrido: " + ex
                });
            }
        }
    }
}