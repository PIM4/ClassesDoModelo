using Model.Entity;
using System;

namespace Model.Entity
{
	public class ContaPagar
	{
		public string tipo{get;set;}
		public Fornecedor fornecedor{get;set;}
		public DateTime data{get;set;}
		public float valor{get;set;}

		public ContaPagar(string tipo, Fornecedor fornecedor, DateTime data, float valor)
		{

		}
	}

}

