using Model.Entity;
using System;

namespace Model.DAO.Generico
{
	public class dbBancos
	{
		public string strConexao { get; set; }

		public dbBancos(string ChaveBase)
		{
			Configuracoes confiracao = new Configuracoes();
			this.strConexao = confiracao.LeStringConexao(ChaveBase);
		}

		public DataTable MetodoSelect(string QuerySQL)
		{
			DataTable tabela = new DataTable();
			try
			{
				using (SqlConnection conexao = new SqlConnection(strConexao))
				{
					using (SqlDataAdapter da = new SqlDataAdapter(QuerySQL, conexao))
					{
						da.Fill(tabela);
					}
				}
			}
			catch (Exception ex)
			{
				tabela = null;
				string err = ex.Message;
				err = "Falha : " + err;
			}
			return tabela;
		}

		public bool MedotoNaoQuery(string QuerySQL)
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
				string err = ex.Message;
				err = "Falha : " + err;
				retorno = false;
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
