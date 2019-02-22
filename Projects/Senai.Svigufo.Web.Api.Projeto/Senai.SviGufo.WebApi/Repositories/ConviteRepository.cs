using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Enums;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class ConviteRepository : IConviteRepository
    {
        // Não esqueça de usar : "user id=sa; pwd=132"
        private string StringConexao = @"Data Source=.\SqlExpress;Initial catalog=SENAI_SVIGUFO_TARDE;user id=sa; password=132";

        public void InscreverConvite(ConviteDomain convite)
        {
            throw new NotImplementedException();
        }

        public List<ConviteDomain> ListarMeusComentarios(int usuarioId)
        {
            string querySelect = @"SELECT
	                                C.ID AS ID_CONVITE,
	                                C.SITUACAO,
	                                E.ID AS ID_EVENTO,
	                                E.TITULO AS TITULO_EVENTO,
	                                E.DATA_EVENTO,
	                                U.ID AS ID_USUARIO,
	                                U.NOME AS NOME_USUARIO,
	                                U.EMAIL AS EMAIL_USUARIO,
	                                TE.ID AS ID_TIPO_EVENTO,
	                                TE.TITULO AS TITULO_TIPO_EVENTO
                                FROM
	                                CONVITES C
		                                INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID
		                                INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID
		                                INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID
                                    WHERE U.ID = @ID_USUARIO";

            List<ConviteDomain> convites;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID_USUARIO", usuarioId);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        convites = new List<ConviteDomain>();

                        while (sdr.Read())
                        {
                            ConviteDomain convite = new ConviteDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                                Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),

                                Evento = new EventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                                    Titulo = sdr["TITULO_EVENTO"].ToString(),
                                    DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                    TipoEvento = new TipoEventoDomain
                                    {
                                        Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                        Nome = sdr["TITULO_TIPO_EVENTO"].ToString(),
                                    }
                                },

                                Usuario = new UsuarioDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                    Nome = sdr["NOME_USUARIO"].ToString(),
                                    Email = sdr["EMAIL_USUARIO"].ToString()
                                },
                            };

                            convites.Add(convite);
                        }

                        return convites;
                    }

                    return null;
                }
            }
        }
           

        public List<ConviteDomain> ListarTodos()
        {
            string querySelect = @"SELECT
	                                C.ID AS ID_CONVITE,
	                                C.SITUACAO,
	                                E.ID AS ID_EVENTO,
	                                E.TITULO AS TITULO_EVENTO,
	                                E.DATA_EVENTO,
	                                U.ID AS ID_USUARIO,
	                                U.NOME AS NOME_USUARIO,
	                                U.EMAIL AS EMAIL_USUARIO,
	                                TE.ID AS ID_TIPO_EVENTO,
	                                TE.TITULO AS TITULO_TIPO_EVENTO
                                FROM
	                                CONVITES C
		                                INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID
		                                INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID
		                                INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID";

            List<ConviteDomain> convites;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        convites = new List<ConviteDomain>();

                        while(sdr.Read())
                        {
                            ConviteDomain convite = new ConviteDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                                Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),

                                Evento = new EventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                                    Titulo = sdr["TITULO_EVENTO"].ToString(),
                                    DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                    TipoEvento = new TipoEventoDomain
                                    {
                                        Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                        Nome = sdr["TITULO_TIPO_EVENTO"].ToString(),
                                    }
                                },

                                Usuario = new UsuarioDomain {
                                    Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                    Nome = sdr["NOME_USUARIO"].ToString(),
                                    Email = sdr["EMAIL_USUARIO"].ToString()
                                },
                            };

                            convites.Add(convite);
                        }

                        return convites;
                    }

                    return null;
                }
            }
        }
    }
}
