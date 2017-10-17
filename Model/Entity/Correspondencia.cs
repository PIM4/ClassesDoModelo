using Model.Entity;
using System;

namespace Model.Entity
{
	public class Correspondencia
	{
		public string descCorespondencia{get;set;}
		public Unidade destinatario{get;set;}
		public DateTime dtEntrada{get;set;}
		public DateTime dtSaida{get;set;}
		public string responsavelRetirada{get;set;}
		public string obsDeCancelamento{get;set;}

		public Correspondencia(string descCorespondencia, string destinatario, DateTime dtEntrada)
		{
			
		}

		public void entregaCorrespondencia(DateTime dtSaida, string responsavelRetirada)
		{

		}
	}

}

