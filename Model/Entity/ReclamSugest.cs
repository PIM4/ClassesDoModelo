using System;
using Model.Entity;

namespace Model.Entity
{
	public class ReclamSugest
	{
		private Condomino autor{get;set;}
		private string titulo{get;set;}
		private string descricao{get;set;}
		private DateTime data{get;set;}
		private bool verificador{get;set;}

		public ReclamSugest(Condomino autor, string titulo, string descricao, bool verificador)
		{

		}

	}
}

