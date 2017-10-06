using System;
using Model.Entity;

namespace Model.Entity
{
	public abstract class Pessoa
	{
		private string nome{get;set;}
		private DateTime data_nasc{get;set;}
		private string rg{get;set;}
		private string cpf{get;set;}
		private Login login{set;get;}
		private List<Endereco> endereco{set;get;}
		private List<Telefone> telefone{set;get;}

		public Pessoa(string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{

		}

	}

}

