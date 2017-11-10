using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class TelefoneDAO
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

        public bool cadastra(Telefone tel)
		{
            query = null;
            try
            {
                query = "INSERT INTO TELEFONE (FIXO, CELULAR, ID_PESSOA, STS_ATIVO, ID_FORNECEDOR)";
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }   //Os cadastros deverão ser jogados dentro de uma mesma lista de telefones.
		}

		public bool remove()
		{

		}

		public List<Telefone> busca()
		{

        }

        #endregion

    }

}

