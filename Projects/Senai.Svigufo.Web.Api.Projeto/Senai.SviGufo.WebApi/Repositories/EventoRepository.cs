using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENAI_SVIGUFO_TARDE;user id=sa; password=132";

        public void Cadastrar(EventoDomain evento)
        {
            string queryInsert = @"INSERT INTO EVENTOS(TITULO,DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_TIPO_EVENTO, ID_INSTITUICAO)
	VALUES (@TITULO, @DESCRICAO, @DATA_EVENTO, @ACESSO_LIVRE, @ID_TIPO_EVENTO, @ID_INSTITUICAO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                    cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                    cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                    cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EventoDomain> Listar()
        {
            List<EventoDomain> listaEventos;

            string querySelect = @"SELECT 
	                                E.ID AS ID_EVENTO,
	                                E.TITULO AS TITULO_EVENTO, 
	                                E.DESCRICAO,
	                                E.DATA_EVENTO,
	                                E.ACESSO_LIVRE,
	                                TE.ID AS ID_TIPO_EVENTO,
	                                TE.TITULO AS TITULO_TIPO_EVENTO,
	                                I.ID AS ID_INSTITUICAO, 
	                                I.NOME_FANTASIA,
	                                I.RAZAO_SOCIAL,
	                                I.CNPJ,
	                                I.LOGRADOURO,
	                                I.CEP,
	                                I.UF,
	                                I.CIDADE
                                   FROM
	                                EVENTOS E 
		                                INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID
		                                INNER JOIN INSTITUICOES I ON E.ID_INSTITUICAO = I.ID";


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    listaEventos = new List<EventoDomain>();

                    while (sdr.Read())
                    {
                        EventoDomain evento = new EventoDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                            Titulo = sdr["TITULO_EVENTO"].ToString(),
                            Descricao = sdr["DESCRICAO"].ToString(),
                            DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                            AcessoLivre = Convert.ToBoolean(sdr["ACESSO_LIVRE"]),

                            TipoEvento = new TipoEventoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                            },

                            Instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_INSTITUICAO"]),
                                RazaoSocial = sdr["RAZAO_SOCIAL"].ToString(),
                                NomeFantasia = sdr["NOME_FANTASIA"].ToString(),
                                CNPJ = sdr["CNPJ"].ToString(),
                                Logradouro = sdr["LOGRADOURO"].ToString(),
                                CEP = sdr["CEP"].ToString(),
                                UF = sdr["UF"].ToString(),
                                Cidade = sdr["CIDADE"].ToString()
                            }
                        };

                        listaEventos.Add(evento);
                    }
                    return listaEventos;
                }
            }
        }

        public void Atualizar(int id, EventoDomain evento)
        {
            string queryUpdate = "UPDATE EVENTOS SET TITULO = @TITULO, DESCRICAO = @DESCRICAO, DATA_EVENTO = @DATA_EVENTO, ACESSO_LIVRE = @ACESSO_LIVRE, ID_TIPO_EVENTO = @ID_TIPO_EVENTO, ID_INSTITUICAO = @ID_INSTITUICAO WHERE ID = @ID";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                    cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                    cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                    cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
