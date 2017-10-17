using System;
using Model.Entity;

namespace Model.Entity
{
	public class Evento
	{
		public string descEvento{get;set;}
		public Unidade unidade{get;set;}
		public list<Area> area{get; set;}
		public int tempMinParaReserva{get;set;}
		public int limitadorDeAreas{get; set;}
		public string resposavel{get;set;}
		public DateTime data{get;set;}

		public Evento(string descEvento, Unidade unidade, int tempMin, string responsavel, DateTime data)
		{

		}
	}

}

