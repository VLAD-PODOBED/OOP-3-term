using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{

    interface IPrototype
    {
        void SetName(string Name);
        string GetName();
        IPrototype Clone();
    }

    class Airline : IPrototype
    {
		public static List<Flight> ListOfFlights { get; set; } = new List<Flight>();
        private string Name { get; set; }
        public Airline() {  }
        public Airline(Airline donor) => this.Name = donor.Name;
        public void SetName(string Name) => this.Name = Name;
        public string GetName() => Name;
        public IPrototype Clone() => new Airline(this);
    }
}