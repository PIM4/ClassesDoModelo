using System;
using Model.Entity;

namespace Model.Entity
{
	public class Telefone
	{
		public string numero{get;set;}
		public string desc{set;get;}
        public Pessoa pessoa { get; set; }
		public Telefone(string tel, string desc)
		{

		}

	}

}

