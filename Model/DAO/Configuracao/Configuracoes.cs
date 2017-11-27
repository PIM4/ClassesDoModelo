using Model.Entity;
using System;

namespace Model.DAO.Configuracao
{
    public class Configuracoes
    {
        public string LeStringConexao()
        {
            //string strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            string strConexao = null;
            try
            {
                strConexao = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\\bruna\\Documents\\bancoTestePim.mdf;Integrated Security=True;Connect Timeout=30";
            }
            catch
            {
                strConexao = null;
            }
            return strConexao;
        }
    }
}
