using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        //data souce = nome do servidor
        //initial catalog = nome do banco
        //user id = usuario
        //password = senha
        // caso seja autenticacao do windows nao passa usuario e senha e passa integrated security=true
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENAI_SVIGUFO_TARDE;user id=sa; password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlteracao = "UPDATE TIPO_EVENTOS SET TITULO = @TITULO WHERE ID =@ID";
                SqlCommand cmd = new SqlCommand(QueryAlteracao, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //query que insere os dados
                string queryInsert = "INSERT INTO TIPO_EVENTOS(TITULO) VALUES(@TITULO)";
                //cria um objeto comando passando como parametro a query e a conexao
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                //atribui o nome do evento ao parametro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                //abre o banco
                con.Open();
                //executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM TIPO_EVENTOS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// lista os tipos de evento
        /// </summary>
        /// <returns>Retorna uma lista de TipoEventosDomain</returns>
        public List<TipoEventoDomain> Listar()
        {
            //objeto que ira retornar na chamada do metodo
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();
            //define a conexao passando a string de conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

                //define o comando que sera executado, no construtor
                //passa a query e a conexao
                using(SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    //abro a conexao com o banco de dados
                    con.Open();

                    //objeto que armazena os dados retonados da execucao da instruçao
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //percorre todos os dados do objeto
                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        //adiciona o objeto na lista de tipos de eventos
                        tiposEventos.Add(tipoEvento);
                    }
                }
                return tiposEventos;
            }
        }
    }
}
