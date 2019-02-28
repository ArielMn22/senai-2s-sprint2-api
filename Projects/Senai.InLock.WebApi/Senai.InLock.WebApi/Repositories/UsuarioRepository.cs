using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=InLock_Games_Tarde;user id=sa; password=132";

        public UsuarioDomain BuscarPorEmaileSenha(string email, string senha)
        {
            string querySelect = "SELECT UsuarioId, Email, Senha, TipoUsuario FROM USUARIOS WHERE Email = @EMAIL AND Senha = @SENHA";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while (sdr.Read())
                        {
                            usuario.UsuarioId = Convert.ToInt32(sdr["UsuarioId"]);
                            usuario.Email = sdr["Email"].ToString();
                            usuario.Senha = sdr["Senha"].ToString();
                            usuario.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }

                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
