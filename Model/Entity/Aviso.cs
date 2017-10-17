using Model.Entity;
using System;

namespace Model.Entity
{
	public class Aviso
	{
		public string titulo{get;set;}
		public string descricao{get;set;}
		public Condominio condominio{get;set;}
		public DateTime data{get;set;}

		public Aviso(string titulo, string descricao, condomino Condominio){

		}
	}

}

