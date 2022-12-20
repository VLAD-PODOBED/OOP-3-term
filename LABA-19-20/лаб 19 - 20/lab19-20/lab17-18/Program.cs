using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static lab17_18.Flight;

namespace lab17_18
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            Print("Паттерн Decorator");
            Collegue colegue = new University();  
            colegue = new Magistr(colegue);                 
            Console.WriteLine("Книга: {0}", colegue.Education);
            Console.WriteLine("Годик: {0}", colegue.GetAge());

            Print("Паттерн State");
            Flight water = new Flight(FlightState.THE_PLANE_IS_ON_THE_RUNWAY); 
            water.Go();
            water.Go();
            water.Stop();

            // Dispetcher - Adapter

            Print("Паттерн Strategy");
            Worker auto = new Worker("sssssssssй", "ssss", new JobHunting()); 
            auto.Move();
            auto.Movable = new GoodJob();
            auto.Move();


            Print("Паттерн Facade");
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);
        }

        public static void Print(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
