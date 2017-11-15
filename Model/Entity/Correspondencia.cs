using Model.Entity;
using System;

namespace Model.Entity
{
	public class Correspondencia
	{
        public int id_correspondencia { get; set; }
		public string descricao{get;set;}
		public DateTime dtEntrada{get;set;}
		public DateTime dtSaida{get;set;}
		public Pessoa responsavelRetirada{get;set;}
		public string obsCanc{get;set;}
        public Unidade unidade { get; set; }
		public Correspondencia(string descCorespondencia, string destinatario, DateTime dtEntrada)
		{
			
		}
        public Correspondencia()
        {

        }
	}

}

