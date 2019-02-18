using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENAI_SVIGUFO_TARDE;user id=sa; password=132";

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> instituicoes = new List<InstituicaoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT ID, RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            InstituicaoDomain instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                                NomeFantasia = reader["NOME_FANTASIA"].ToString(),
                                CNPJ = reader["CNPJ"].ToString(),
                                Logradouro = reader["LOGRADOURO"].ToString(),
                                CEP = reader["CEP"].ToString(),
                                UF = reader["UF"].ToString(),
                                Cidade = reader["CIDADE"].ToString()
                            };

                            instituicoes.Add(instituicao);
                        }
                        return instituicoes;
                    } else
                    {
                        return null;
                    }
                }
            }
        }

        public InstituicaoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSITUICOES WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows)
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            RazaoSocial = reader["RAZAO_SOCIAL"].ToString(),
                            NomeFantasia = reader["NOME_FANTASIA"].ToString(),
                            CNPJ = reader["CNPJ"].ToString(),
                            Logradouro = reader["LOGRADOURO"].ToString(),
                            CEP = reader["CEP"].ToString(),
                            UF = reader["UF"].ToString(),
                            Cidade = reader["CIDADE"].ToString()
                        };

                        return instituicao;
                    } else
                    {
                        return null;
                    }
                }
            }
        }

        public void Cadastrar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO INSTITUICOES(RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE) VALUES(@RAZAO_SOCIAL, @NOME_FANTASIA, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", instituicao.UF);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE INSTITUICOES SET RAZAO_SOCIAL = @RAZAO_SOCIAL, NOME_FANTASIA = @NOME_FANTASIA, CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, UF = @UF, CIDADE = @CIDADE WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(queryUpdate, con);

                cmd.Parameters.AddWithValue("@ID", instituicao.Id);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", instituicao.UF);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM INSTITUICOES WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(queryDelete, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
