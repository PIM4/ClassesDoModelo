using Model.Entity;
using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using Model.DAO.Configuracao;

namespace Model.DAO.Generico
{
	public class dbBancos
	{
        public string strConexao { get; set; }

        public dbBancos()
        {

        }

        public dbBancos(string ChaveBase)
        {
            Configuracoes configuracao = new Configuracoes();
            this.strConexao = configuracao.LeStringConexao(ChaveBase);
        }

        public SqlDataReader MetodoSelect(string QuerySQL)
		{
			//DataTable tabela = new DataTable();
            SqlConnection conexao = new SqlConnection(strConexao);
            SqlCommand cmd = new SqlCommand(QuerySQL);
			//SqlDataAdapter da = new SqlDataAdapter(QuerySQL, conexao);
			try
			{
                conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();
			    //da.Fill(tabela);
                return dr;
			}
			catch (Exception ex)
			{
				//tabela = null;
                throw ex;
			}
            finally
            {
                conexao.Close();
                //da.Dispose();
                cmd.Dispose();
            }
		}

		public bool MetodoNaoQuery(string QuerySQL)
		{
			bool retorno = false;
			SqlConnection conexao = null;
			SqlCommand comando = null;
			try
			{
				conexao = new SqlConnection(strConexao);
				comando = new SqlCommand(QuerySQL, conexao);
				conexao.Open();
				comando.ExecuteNonQuery();
				retorno = true;
			}
			catch (Exception ex)
			{
                retorno = false;
                throw ex;
			}
			finally
			{
				if (conexao != null)
				{
					conexao.Close();
				}
			}
			return retorno;
		}

	}
}
