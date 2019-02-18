using Senai.Produtos.WebAPI.Tarde.Domains;
using Senai.Produtos.WebAPI.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebAPI.Tarde.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENAI_PRODUTOS_TARDE;user id=sa;password=132";

        public void Cadastrar(ProdutoDomain produto)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO PRODUTOS(NOME, DESCRICAO) VALUES(@NOME, @DESCRICAO)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@NOME", produto.Nome);
                cmd.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ProdutoDomain> Listar()
        {
            List<ProdutoDomain> produtos;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT ID, NOME, DESCRICAO FROM PRODUTOS";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        produtos = new List<ProdutoDomain>();

                        while (sdr.Read())
                        {
                            ProdutoDomain produto = new ProdutoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID"]),
                                Nome = sdr["NOME"].ToString(),
                                Descricao = sdr["DESCRICAO"].ToString()
                            };

                            produtos.Add(produto);
                        }
                        return produtos;
                    } else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
