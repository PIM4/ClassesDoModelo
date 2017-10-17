using Model.Entity;
using System;

namespace Model.Entity
{
	public class Area
	{
		public string nome{get;set;}
		public string descricao{get;set;}
		public int capacMax{get;set;}
		public bool seAluga{get;set;}

		public Area(string nome, int capacMax, bool seAluga)
		{

		}
	}

}

