using Model.Entity;
using System;

namespace Model.Entity
{
	public class Bloco
	{
		public string nome{get;set;}
		public int qtAndares{get;set;}
		public int qtApto{get;set;}	
		public Condominio condominio{get;set;}

		public Bloco(string nome, condominio Condominio)
		{
			
		}

	}

}

