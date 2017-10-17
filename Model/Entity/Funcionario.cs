using Model.Entity;
using System;

namespace Model.Entity
{
	public class Funcionario : Pessoa
	{
		public Cargo cargo{get;set;}

		public Funcionario(cargo Cargo, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
	}

}

