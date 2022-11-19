using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    public partial class Morrowind //partial class может объединяться с классом с таким же название из другого файла, при наличии ключ. слова partial
    {
        public void func_1()
        {
            Console.Write("ыыыыыыыыыыыыы, ");
        }
    }

    public class Bus
    {

        private string surname;
        public string Name
        {
            set //Устанавливаем значение поля - действия, выполняемые при получении значения свойства
            {
                if (surname == "")
                {
                    Console.WriteLine("Фамилия не задано");
                }
                else
                {
                    surname = value;
                }
            }
            get //Возваращем значения поля - действия, выполняемые при установке значения свойства
            {
                return surname;
            }
        }

        private string initials;
        public string Initials
        {
            set
            {
                if (initials == "")
                {
                    Console.WriteLine("Иниц. не задано");
                }
                else
                {
                    initials = value;
                }
            }
            get
            {
                return initials;
            }
        }

        private string numberBus;
        public string NumberBus
        {
            set
            {
                if (numberBus == "")
                {
                    Console.WriteLine("Издательство не задано");
                }
                else
                {
                    numberBus = value;
                }
            }
            get
            {
                return numberBus;
            }
        }
        public int route { get; set; }
        public string stamp { get; set; }
        public int year { get; set; }
        public string mileage { get; set; }

        public static int count = 0;

        public Random rnd = new Random();

        public readonly int ID;

        static Bus() // Вызывается один раз при создании класса
        {
            Console.WriteLine("Начинаем");
        }
        public Bus(string surname, string initials, string numberBus, int route, string stamp, int year, string mileage, int ID)
        {
            this.surname = surname;
            this.initials = initials;
            this.numberBus = numberBus;
            this.route = route;
            this.stamp = stamp;
            this.year = year;
            this.mileage = mileage;
            this.ID = rnd.Next();
            count++;
            Print();
        }
        string a;
        private Bus(string a) //private class
        {
            this.a = a;
        }


        public void Print()
        {
            Console.WriteLine("Фамилия: " + surname);
            Console.WriteLine("Имя: " + initials);
            Console.WriteLine("номер автобуса: " + numberBus);
            Console.WriteLine("номер маршрутка: " + route);
            Console.WriteLine("марка: " + stamp);
            Console.WriteLine("год: " + year);
            Console.WriteLine("пробег: " + mileage);
            var testpri = new Bus("private is work"); //Создаем экземпляр private класса
            Console.WriteLine(testpri.a);
            Console.WriteLine();
            Console.WriteLine("Количество хранящихся объектов: " + count);
        }

        public static void Stat(ref int count) // ref - передача по ссылке. При передаче по ссылку изменяется сама перменная 
        {

        }
        //out работает для выходных параметров можно не использовать return
    }

    class Program
    {
        static void Create(Bus[] bus)
        {
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            string initials = Console.ReadLine();
            Console.WriteLine("Введите номер автобуса: ");
            string numberBus = Console.ReadLine();
            Console.WriteLine("Введите номер маршрутка: ");
            int route = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите марку: ");
            string stamp = Console.ReadLine();
            Console.WriteLine("Введите годик: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пробег: ");
            string mileage = Console.ReadLine();
            int ID = 0;


            Bus Bus0 = new Bus(surname, initials, numberBus, route, stamp, year, mileage, ID);
            bus[0] = Bus0;

            if (surname == "") Bus0.Name = "";
            if (initials == "") Bus0.Initials = "";
            if (numberBus == "") Bus0.NumberBus = "";
        }
        static void Main(string[] args)
        {
            Bus Bus1 = new Bus("Подобед", "Владислав", "123", 1953, "мерс", 2005, "346789", 0);
            Bus Bus2 = new Bus("Деонова", "Владик", "765", 2103, "гг", 2000, "10000", 0);



            Bus[] bus = new Bus[3];
            Create(bus);
            bus[1] = Bus1;
            bus[2] = Bus2;
            Console.ReadKey();

            Console.WriteLine("Введите имя автора: ");
            string name = Console.ReadLine();
            for (int i = 0; i < bus.Length; i++)
            {
                if (bus[i].Initials == name)
                {
                    Console.WriteLine("Фамилия: " + bus[i].Name);
                    Console.WriteLine("Имя: " + bus[i].Initials);
                    Console.WriteLine("номер автобуса: " + bus[i].NumberBus);
                    Console.WriteLine("номер маршрутка: " + bus[i].route);
                    Console.WriteLine("марка: " + bus[i].stamp);
                    Console.WriteLine("год: " + bus[i].year);
                    Console.WriteLine("пробег: " + bus[i].mileage);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Console.WriteLine("Введите год: ");
            int year = int.Parse(Console.ReadLine());
            for (int i = 0; i < bus.Length; i++)
            {
                if (bus[i].route > year)
                {
                    Console.WriteLine("Фамилия: " + bus[i].Name);
                    Console.WriteLine("Имя: " + bus[i].Initials);
                    Console.WriteLine("номер автобуса: " + bus[i].NumberBus);
                    Console.WriteLine("номер маршрутка: " + bus[i].route);
                    Console.WriteLine("марка: " + bus[i].stamp);
                    Console.WriteLine("год: " + bus[i].year);
                    Console.WriteLine("пробег: " + bus[i].mileage);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Morrowind nerevar = new Morrowind();
            nerevar.func_1();
            nerevar.func_2();
            Console.ReadKey();

            Bus.Stat(ref Bus.count);
            Console.ReadKey();

        }
    }
}