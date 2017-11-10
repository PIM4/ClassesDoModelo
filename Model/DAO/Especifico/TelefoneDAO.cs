using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;
using System.Data;

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
                query = "INSERT INTO TELEFONE (FIXO, CELULAR, ID_PESSOA, STS_ATIVO, ID_FORNECEDOR) VALUES(" + tel.fixo;
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }   //Os cadastros deverão ser jogados dentro de uma mesma lista de telefones.

        public List<Telefone> busca(int id_pessoa)
        {
            query = null;
            List<Telefone> lstTelefone = new List<Telefone>();
            try
            {
                query = "SELECT FIXO, CELULAR, DESCRICAO FROM TELEFONE"
                        + " WHERE STS_ATIVO = 1 AND ID_PESSOA = " + (id_pessoa).ToString();
                lstTelefone.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTelefone;	
        }

        public List<Telefone> buscaFornecedor(int id_fornecedor)
        {
            query = null;
            List<Telefone> lstTelefone = new List<Telefone>();
            try
            {
                query = "SELECT FIXO, CELULAR WHERE STS_ATIVO = 1 AND ID_FORNECEDOR = " + (id_fornecedor).ToString();
                lstTelefone.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstTelefone;
        }

        public bool altera(Endereco end)
        {
            query = null;
            try
            {
                query = "UPDATE ENDERECO SET LOGRADOURO = " + end.logradouro + ", NUMERO = " + (end.numero).ToString() + ", COMPLEMENTO = "
                        + end.complemento + ", BAIRRO = " + end.bairro + ", CIDADE = " + end.cidade + ", ESTADO = " + end.estado + ", CEP = "
                        + end.cep + ", DESCRICAO = " + end.descricao + " WHERE ID_ENDERECO = " + (end.id_endereco).ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

		public bool remove()
		{

		}

        #endregion

        #region Métodos

        public Telefone setarObjeto(SqlDataReader dr)
        {
            Telefone obj = new Telefone();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_ENDERECO":
                            obj.id_endereco = Convert.ToInt32(dr[idx]);
                            break;
                        case "DESCRICAO":
                            obj.descricao = Convert.ToString(dr[idx]);
                            break;
                        case "LOGRADOURO":
                            obj.logradouro = Convert.ToString(dr[idx]);
                            break;
                        case "NUMERO":
                            obj.numero = Convert.ToInt32(dr[idx]);
                            break;
                        case "COMPLEMENTO":
                            obj.complemento = Convert.ToString(dr[idx]);
                            break;
                        case "BAIRRO":
                            obj.bairro = Convert.ToString(dr[idx]);
                            break;
                        case "CIDADE":
                            obj.cidade = Convert.ToString(dr[idx]);
                            break;
                        case "ESTADO":
                            obj.estado = Convert.ToString(dr[idx]);
                            break;
                        case "CEP":
                            obj.cep = Convert.ToString(dr[idx]);
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

