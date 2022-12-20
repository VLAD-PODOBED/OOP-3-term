using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Administrator
    {
        private static Administrator instance;  // SIngleton
        private Administrator() {   }
        public static Administrator getInstance()
        {
            if (instance == null)
                instance = new Administrator();
            return instance;
        }

        public void ChangeFlight(Flight flight)
        {
            foreach (var item in X.ListOfFlights)
            {
                if(item.FlightName == flight.FlightName)
                {
                    Console.Write("\nВведите новое издательство: ");
                    item.PropWhereFrom = Console.ReadLine();
                    Console.Write("\nВведите подписку: ");
                    item.PropWhere = Console.ReadLine();
                    Console.Write("\nВведите новую дату полписки: ");
                    item.PropDepartureTime = DateTime.Parse(Console.ReadLine());
                }
            }
        }
        public void DelFlight(Flight flight) => X.ListOfFlights.Remove(flight); 
        public void AddFlight(string WhereFrom, string Where, DateTime DepartureTime) => X.ListOfFlights.Add(new Flight(WhereFrom, Where, DepartureTime));
        public void ShowListOfFlights()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n Типо читатели: ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in X.ListOfFlights)
            {
                Console.WriteLine("Nickname: " + item.FlightName);
                Console.WriteLine("Псевдоним: " + item.PropWhere);
                Console.WriteLine("Имя: " + item.PropWhereFrom);
                Console.WriteLine("Время захода на сайт: " + item.PropDepartureTime);
                
                new Dispatcher().ShowBrigade(item.brigade);

                Console.WriteLine("\n");
            }
            Console.ResetColor();
        }
    }
}
