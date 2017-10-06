using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaPagar
	{
		private string tipo{get;set;}
		private Fornecedor fornecedor{get;set;}
		private DateTime data{get;set;}
		private float valor{get;set;}

		public ContaPagar(string tipo, Fornecedor fornecedor, DateTime data, float valor)
		{

		}
	}

}

