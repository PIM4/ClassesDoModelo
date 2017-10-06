using Model.Entity;
using System;

namespace Model.Entity
{
	public class Condominio
	{
		private string nome{get;set;}
		private Endereco endereco{get;set;}		
		private int qtdBlocos{get;set;}		
		private string proprietario{get;set;}
		private string cnpj{get;set;}
		private DateTime dataInauguracao{get;set;}
		
		public Condominio(string nome, Endereco endereco, string proprietario, string cnpj, DateTime dtInau)
		{

		}
	}

}

