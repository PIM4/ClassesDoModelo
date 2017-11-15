using Model.Entity;
using System;
using System.Collections.Generic;
using Model.DAO.Generico;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
    public class ContaReceberDAO
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

        public bool cadastra(ContaReceber cr)
        {
            CondominioDAO cond = new CondominioDAO();
            query = null;
            try
            {
                query = "INSERT INTO CONTA_RECEBER (DT_CONTA_RECEBER, VALOR, ID_COND, ID_UNIDADE, STS_ATIVO) VALUES ('"
                        + (cr.data).ToShortDateString() + "', " + (cr.valor).ToString() + ", " + (cond.buscaID()).ToString()
                        + ", " + (cr.unidade.id_unidade).ToString() + ", 1)";
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<ContaReceber> buscaPorValor(int v1, int v2)
        {
            query = null;
            List<ContaReceber> lstContaReceber = new List<ContaReceber>();
            try
            {
                query = "SELECT CR.DT_CONTA_RECEBER, CR.VALOR, U.IDENTIFICACAO FROM CONTA_RECEBER AS CR "
                        + " INNER JOIN UNIDADE AS U ON CR.ID_UNIDADE = U.ID_UNIDADE "
                        + " WHERE CR.STS_ATIVO = 1 AND CR.VALOR BETWEEN " + (v1).ToString() + " AND " + (v2).ToString();
                lstContaReceber.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaReceber;
        }

        public List<ContaReceber> buscaPorData(DateTime dt1, DateTime dt2)
        {
            query = null;
            List<ContaReceber> lstContaReceber = new List<ContaReceber>();
            try
            {
                query = "SELECT CR.DT_CONTA_RECEBER, CR.VALOR, U.IDENTIFICACAO FROM CONTA_RECEBER AS CR "
                        + " INNER JOIN UNIDADE AS U ON CR.ID_UNIDADE = U.ID_UNIDADE "
                        + " WHERE CR.STS_ATIVO = 1 AND CR.DT_CONTA_RECEBER BETWEEN " + (dt1).ToShortDateString() + " AND " 
                        + (dt2).ToShortDateString();
                lstContaReceber.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaReceber;
        }

        public List<ContaReceber> buscaPorCondominio(Condominio condominio)
		{
            query = null;
            List<ContaReceber> lstContaReceber = new List<ContaReceber>();
            try
            {
                query = "SELECT CR.DT_CONTA_RECEBER, CR.VALOR, U.IDENTIFICACAO FROM CONTA_RECEBER AS CR "
                        + " INNER JOIN UNIDADE AS U ON CR.ID_UNIDADE = U.ID_UNIDADE "
                        + " WHERE CR.STS_ATIVO = 1 AND CR.ID_COND = " + (condominio.id_cond).ToString();
                lstContaReceber.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaReceber;
        }

        public List<ContaReceber> buscaPorUnidade(Unidade unidade)
		{
            query = null;
            List<ContaReceber> lstContaReceber = new List<ContaReceber>();
            try
            {
                query = "SELECT CR.DT_CONTA_RECEBER, CR.VALOR, U.IDENTIFICACAO FROM CONTA_RECEBER AS CR "
                        + " INNER JOIN UNIDADE AS U ON CR.ID_UNIDADE = U.ID_UNIDADE "
                        + " WHERE CR.STS_ATIVO = 1 AND CR.ID_UNIDADE = " + (unidade.id_unidade).ToString();
                lstContaReceber.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaReceber;  
        }

        public List<ContaReceber> busca()
		{
            query = null;
            List<ContaReceber> lstContaReceber = new List<ContaReceber>();
            try
            {
                query = "SELECT CR.DT_CONTA_RECEBER, CR.VALOR, U.IDENTIFICACAO FROM CONTA_RECEBER AS CR "
                        + " INNER JOIN UNIDADE AS U ON CR.ID_UNIDADE = U.ID_UNIDADE "
                        + " WHERE CR.STS_ATIVO = 1";
                lstContaReceber.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstContaReceber;  
        }

        public bool altera(ContaReceber cr)
        {
            query = null;
            try
            {
                query = "UPDATE CONTA_RECEBER SET DT_CONTA_RECEBER = " + (cr.data).ToShortDateString() + ", VALOR = " + (cr.valor).ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE CONTA_RECEBER SET STS_ATIVO = 0 WHERE ID_CONTA_RECEBER = " + id.ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion

        #region Métodos

        public ContaReceber setarObjeto(SqlDataReader dr)
        {
            ContaPagar obj = new ContaPagar();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "DESCRICAO":
                            obj.desc_conta = Convert.ToString(dr[idx]);
                            break;
                        case "RAZAO_SOCIAL":
                            obj.fornecedor.nomeEmpresa = Convert.ToString(dr[idx]);
                            break;
                        case "VALOR":
                            obj.valor = Convert.ToDecimal(dr[idx]);
                            break;
                        case "DT_PAGTO":
                            obj.data = Convert.ToDateTime(dr[idx]);
                            break;
                        case "ID_FORNECEDOR":
                            obj.fornecedor.id_fornecedor = Convert.ToInt32(dr[idx]);
                            break;
                        case "ID_TIPO_CONTA":
                            obj.id_tipo = Convert.ToInt32(dr[idx]);
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

