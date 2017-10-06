using System;
using Model.Entity;

namespace Model.Entity
{
	public class Evento
	{
		private string descEvento{get;set;}
		private Unidade unidade{get;set;}
		private list<Area> area{get; set;}
		private int tempMinParaReserva{get;set;}
		private int limitadorDeAreas{get; set;}
		private string resposavel{get;set;}
		private DateTime data{get;set;}

		public Evento(string descEvento, Unidade unidade, int tempMin, string responsavel, DateTime data)
		{

		}
	}

}

