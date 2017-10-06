using Model.Entity;
using System;

namespace Model.Entity
{
	public class Unidade
	{
		private string identificacao{get;set;}
		private Proprietario proprietario{get;set;}
		private Bloco bloco{get;set;}
		private int vagas{get;set;}
		
		public Unidade(Bloco bl, string identificacao, int vagas, Proprietario proprietario)
		{

		}

	}

}

