using System;
using Model.Entity;

namespace Model.Entity
{
	public abstract class Pessoa
	{
		public string nome{get;set;}
		public DateTime data_nasc{get;set;}
		public string rg{get;set;}
		public string cpf{get;set;}
		public Login login{set;get;}
		public List<Endereco> endereco{set;get;}
		public List<Telefone> telefone{set;get;}

		public Pessoa(string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{

		}

	}

}

