using Model.Entity;
using System;

namespace Model.Entity
{
	public class Condomino : Pessoa
	{
		private bool morador{get;set;}
		private bool proprietario{get;set;}

		public Condomino(bool morador, bool proprietario, string nome, string rg, string documento, List<Endereco> endereco, List<Telefone> telefone)
		{
			
		}
	}

}

