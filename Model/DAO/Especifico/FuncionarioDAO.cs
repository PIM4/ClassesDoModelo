using Model.Entity;
using System;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class FuncionarioDAO
	{
        #region Observações

        //Por padrão, todas as buscas serão WHERE STS_ATIVO = 1, exceto a verificação se já existe o cadastro.
        //O prof Cassiano orientou a implementar o setarObjeto() dessa forma que foi feita, pq todas as classes precisam, com parametros e objetos diferentes. Não vale o trampo de abstrair.

        #endregion

        #region Objetos

        dbBancos banco = new dbBancos();
        string query = null;

        #endregion

        #region CRUD

		public bool cadastra(Funcionario funcionario)
		{
	        return
        }

		public bool remove()
		{
	        return
        }

        #endregion

        #region Métodos

        public Pessoa setarObjeto(SqlDataReader dr)
        {
            Pessoa obj = new Pessoa();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_PESSOA":
                            obj.id_pessoa = Convert.ToInt32(dr[idx]);
                            break;
                        case "NOME":
                            obj.nome = Convert.ToString(dr[idx]);
                            break;
                        case "CPF":
                            obj.cpf = Convert.ToString(dr[idx]);
                            break;
                        case "RG":
                            obj.rg = Convert.ToString(dr[idx]);
                            break;
                        case "DT_NASC":
                            obj.data_nasc = Convert.ToDateTime(dr[idx]);
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return obj;
        }

        #endregion
	}

}

