using Model.Entity;
using System;
using System.Data;
using System.Collections.Generic;
using Model.DAO;
using Model.DAO.Generico;
using System.Data;
using System.Data.SqlClient;

namespace Model.DAO.Especifico
{
	public class AreaDAO
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

        public bool cadastra(Area area)
		{
            query = null;
            try
            {
                query = "INSERT INTO AREA (DESCRICAO, RESERVA, NOME, CAPACIDADE_MAX, STS_ATIVO) VALUES ("
                                + area.descricao + ", " + (area.seAluga).ToString() + ", " + area.nome + ", "
                                + (area.capacMax).ToString() + ", 1)";
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

		public List<Area> buscaPorNome(string nome)
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE NOME LIKE '%" + nome + "%'  WHERE STS_ATIVO = 1";
                lstArea.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

		public List<Area> buscaPorAlugaveis(bool aluga)
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE RESERVA = " + aluga + " WHERE STS_ATIVO = 1";
                lstArea.Add(setarObjeto(banco.MetodoSelect(query)));
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

		public List<Area> busca()
		{
            query = null;
            List<Area> lstArea = new List<Area>();
            try
            {
                query = "SELECT NOME, DESCRICAO, CAPACIDADE_MAX, RESERVA FROM AREA WHERE STS_ATIVO = 1";
                lstArea.Add(setarObjeto(banco.MetodoSelect(query)));
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return lstArea;
		}

		public bool remove(int id)
		{
            query = null;
            try
            {
                query = "UPDATE AREA SET STS_ATIVO = 0 WHERE ID_AREA = " + id.ToString();
                banco.MetodoNaoQuery(query);
                return true;
            }

            catch(Exception ex)
            {
                return false;
                throw ex;
            }
		}

        #endregion

        #region Métodos

        public Area setarObjeto(SqlDataReader dr)
        {
            Area obj = new Area();

            try
            {
                for (int idx = 0; idx < dr.FieldCount; idx++)
                {
                    dr.GetName(idx).ToString();

                    switch (dr.GetName(idx).ToUpper())
                    {
                        case "ID_AREA":
                            obj.id_area = Convert.ToInt32(dr[idx]);
                            break;
                        case "DESCRICAO":
                            obj.descricao = Convert.ToString(dr[idx]);
                            break;
                        case "RESERVA":
                            obj.seAluga = Convert.ToBoolean(dr[idx]);
                            break;
                        case "NOME":
                            obj.nome = Convert.ToString(dr[idx]);
                            break;
                        case "CAPACIDADE_MAX":
                            obj.capacMax = Convert.ToInt32(dr[idx]);
                            break;
                    }
                }
            }

            catch(Exception ex)
            {
                dr.Dispose();
                throw ex;
            }

            return obj;
        }

        #endregion
    }
}

