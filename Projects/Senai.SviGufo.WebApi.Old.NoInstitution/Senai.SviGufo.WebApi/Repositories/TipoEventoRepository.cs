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
        //Data Source - Nome do servidor.
        //Initial Catalogo - Nome do banco.
        //User Id - Usuário
        //Password - Senha
        //Caso seja autenticação do windows não passa usuário e senha, passa 'integrated security=true'
        private string StringConexao = @"Data Source=.\SqlExpress;initial catalog=SENAI_SVIGUFO_TARDE;user id=sa;password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE TIPOS_EVENTOS SET TITULO = @TITULO WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(queryUpdate, con);

                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("ID", tipoEvento.Id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        //private string StringConexao = @"Data Source=.\SqlExpress;initial catalog=SENAI_SVIGUFO_TARDE;integrated security=true"; // Utiliza a autenticação do Windows.

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            //Declato a minha conexãom e passo como parâmetro a String de Conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query que insere os dados
                string queryInsert = "INSERT INTO TIPO_EVENTOS(TITULO) VALUES(@TITULO)";

                //Cria um objeto comando passando como parâmetro a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                //Atribui o nome do evento ao parâmetro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);

                //Abre o banco
                con.Open();

                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM TIPOS_EVENTOS WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(queryDelete, con);

                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista os tipos de eventos.
        /// </summary>
        /// <returns>Retorna uma Lista de TipoEventoDomain.</returns>
        public List<TipoEventoDomain> Listar()
        {
            //Declarando lista
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            //Define a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPOS_EVENTOS";
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    //Abro a conexão com o banco de dados
                    con.Open();

                    //Objeto que é responsável por ler os dados.
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //Percorre todos os dados do objeto.
                    while(rdr.Read())
                    {
                        //Crio um objeto tipo evento e atribuo os valores das colunas a ele.
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);
                    }
                }
            }
            return tiposEventos;
        }
    }
}
