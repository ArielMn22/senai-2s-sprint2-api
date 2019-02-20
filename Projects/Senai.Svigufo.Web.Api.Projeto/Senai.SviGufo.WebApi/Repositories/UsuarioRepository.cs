using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial Catalog=SENAI_SVIGUFO_TARDE;Persist Security Info=True;User ID=sa;Password=132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT ID, NOME, EMAIL, SENHA, TIPO_USUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();

                        while(sdr.Read())
                        {
                            usuarioBuscado.Id = Convert.ToInt32(sdr["ID"]);
                            usuarioBuscado.Nome = sdr["NOME"].ToString();
                            usuarioBuscado.Email = sdr["EMAIL"].ToString();
                            usuarioBuscado.TipoUsuario = sdr["TIPO_USUARIO"].ToString();
                        }

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            string queryInsert = "INSERT INTO USUARIOS(NOME, EMAIL, SENHA, TIPO_USUARIO) VALUES(@NOME, @EMAIL, @SENHA, @TIPO_USUARIO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@TIPO_USUARIO", usuario.TipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
