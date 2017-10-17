using System;
using Model.Entity;

namespace Model.Entity
{
	public class Enquete
	{
		public string pergunta{get;set;}
		public string dtInicio{get;set;}
		public string dtFim{get;set;}
		public List<string> opVotos{get; set;}

		public Enquete(string pergunta, string dtInicio, string dtFim, List opVotos)
		{

		}
		
	}
}

