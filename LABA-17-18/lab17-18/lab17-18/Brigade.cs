using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Brigade
    {
        private static int CountBrigade = 0;
        
        public List<Worker> BrigadeListWorker = new List<Worker>();
        private string BrigadeName;
        public string Name
        {
            get { return BrigadeName; }
            set { BrigadeName = value; }
        }

        public Brigade()
        {
            CountBrigade++;
            Name = $"Каталог #{CountBrigade}";
        }
    }
}
