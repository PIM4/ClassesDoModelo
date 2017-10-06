using Model.Entity;
using System;

namespace Model.Entity
{
	public class Fornecedor
	{
		private string nomeEmpresa{get;set;}
		private string ramo{get;set;}
		private string cnpj{get;set;}
		private List<Endereco> endereco{get;set;}
		private List<Telefone> telefone{get;set;}

		public Fornecedor(string nomeEmpresa, string ramo, string cnpj, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
	}

}

