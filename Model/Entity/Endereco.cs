using Model.Entity;
using System;

namespace Model.Entity
{
	public class Endereco
	{
		private string logradouro{get;set;}
		private int numero{get;set;}
		private string complemento{get;set;}
		private string bairro{get;set;}
		private int cep{get;set;}
		private string cidade{get;set;}
		private string estado{get;set;}

		public Endereco(string cep, string log, int num, string bairro, string cidade)
		{

		}
	}

}

