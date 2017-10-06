using Model.Entity;
using System;

namespace Model.Entity
{
	public class Correspondencia
	{
		private string descCorespondencia{get;set;}
		private Unidade destinatario{get;set;}
		private DateTime dtEntrada{get;set;}
		private DateTime dtSaida{get;set;}
		private string responsavelRetirada{get;set;}
		private string obsDeCancelamento{get;set;}

		public Correspondencia(string descCorespondencia, string destinatario, DateTime dtEntrada)
		{
			
		}

		public void entregaCorrespondencia(DateTime dtSaida, string responsavelRetirada)
		{

		}
	}

}

