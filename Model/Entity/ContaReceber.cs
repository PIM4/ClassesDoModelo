using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaReceber
	{
		private Condominio condominio{get;set;}
		private Unidade unidade{get;set;}
		private DateTime data{get;set;}
		private string observacao{set;get;}
		private float valor{get;set;}

		public ContaReceber(Condominio condominio, float valor, Unidade uni, float valor)
		{

		}
	}

}

