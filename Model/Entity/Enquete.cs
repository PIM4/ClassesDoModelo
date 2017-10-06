using System;
using Model.Entity;

namespace Model.Entity
{
	public class Enquete
	{
		private string pergunta{get;set;}
		private string dtInicio{get;set;}
		private string dtFim{get;set;}
		private List<string> opVotos{get; set;}

		public Enquete(string pergunta, string dtInicio, string dtFim, List opVotos)
		{

		}
		
	}
}

