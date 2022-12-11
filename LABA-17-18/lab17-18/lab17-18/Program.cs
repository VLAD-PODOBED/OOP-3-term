using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var administrator = Administrator.getInstance();


            var brigade1 = new Brigade();
            var brigade2 = new Brigade();
            var brigade3 = new Brigade();
            var brigade4 = new Brigade();

            var worker1 = new Worker("Джордж Оруэлл", "Скотный двор");
            var worker2 = new Worker("Джордж Оруэлл", "1984");
            var worker3 = new Worker("Мосян Тунсю", "Благословение небожителей. Том 2");
            var worker4 = new Worker("Оскар Уайльд", "Портрет Дориана Грея");

            administrator.AddFlight("Влад", "POdobed", DateTime.Parse("25.12.2022 23:20"));
            administrator.AddFlight("Никита", "Dimbildon", DateTime.Parse("18.11.2022"));
            administrator.AddFlight("Данила", "GAGA", DateTime.Parse("27.10.2022"));
            administrator.AddFlight("Андрей", "Flicker", DateTime.Parse("03.10.2022"));

            dispatcher.AddAWorkerToTheBrigade(brigade1, worker1, worker2, worker3, worker4);
            dispatcher.AddAWorkerToTheBrigade(brigade2, worker2, worker2, worker2, worker2);
            dispatcher.AddAWorkerToTheBrigade(brigade3, worker3, worker3, worker3, worker3);
            dispatcher.AddAWorkerToTheBrigade(brigade4, worker4, worker3, worker2, worker1);


            dispatcher.ShowBrigade(brigade1);

            dispatcher.AddBrigadeToTheFlight(brigade1, "Влад-POdobed");
            dispatcher.AddBrigadeToTheFlight(brigade2, "Никита-Dimbildon");
            dispatcher.AddBrigadeToTheFlight(brigade3, "Данила-GAGA");

            administrator.ShowListOfFlights();


            List<Worker> workers = new List<Worker>()
            {
                new Worker("Портрет Дориана Грея", "defwef"),
                new Worker("fefe", "fwefewf"),
                new Worker("fefe", "fwf"),
                new Worker("fefe", "fewfewf")
            };


            //var builder = new Builder(workers);

            var builder = new Builder(Builder.GerRandom(6));

            var director = new Director(builder);

            director.Build();

            var result = builder.GetResult();

            dispatcher.AddBrigadeToTheFlight(result, "Андрей-Flicker");

            dispatcher.ShowBrigade(result);

            /// Prototype

            IPrototype AirlineDonor = new Airline();
            AirlineDonor.SetName("Mrmamam");

            IPrototype AirlineClone = AirlineDonor.Clone();

            Console.WriteLine(AirlineDonor.GetName());
            Console.WriteLine(AirlineClone.GetName());

        }
    }
}
