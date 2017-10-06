using Model.Entity;
using System;

namespace Model.DAO.Configuracao
{
    public class Configuracoes
    {
        public string LeStringConexao(string Chave)
        {
            string strConexao = "";

            try
            {
                strConexao = System.Configuration.ConfigurationManager.ConnectionStrings[Chave].ConnectionString;
            }
            catch
            {
                strConexao = string.Empty;
            }
            return strConexao;
        }
    }
}
