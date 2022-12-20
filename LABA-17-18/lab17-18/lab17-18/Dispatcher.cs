using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Dispatcher
    {
		private string Name;

		public string PropName
		{
			get { return Name; }
			set { Name = value; }
		}
		public void AddAWorkerToTheBrigade(Brigade brigade, params Worker[] workers)
		{
			foreach (var item in workers)
			{
				brigade.BrigadeListWorker.Add(item);
			}
		}
        public void DelAWorkerToTheBrigade(Brigade brigade, Worker worker) => brigade.BrigadeListWorker.Remove(worker);
		public void AddBrigadeToTheFlight(Brigade brigade, string FlightName)
		{
			foreach (var item in X.ListOfFlights)
			{
				if (item.FlightName == FlightName)
				{
					item.brigade = brigade;
					Console.WriteLine("Подписка  добавлена на сайт");
				}
            }
		}
		public void ShowBrigade(Brigade brigade)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Список книг в каталоге \"{0}\"", brigade.Name);
			Console.ForegroundColor = ConsoleColor.White;
			foreach (var item in brigade.BrigadeListWorker)
			{
				Console.WriteLine("Имя: {0} | Книга: {1}", item.NameWorker, item.Post);
			}
			Console.ResetColor();
		}

    }
}
