using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Builder : IWorkerBuilder
    {
        private Brigade brigade;

        private readonly List<Worker> ListOfWorkers;

        public Builder(List<Worker> ListOfWorkers)
        {
            this.ListOfWorkers = ListOfWorkers;
            brigade = new Brigade();
        }

        public void AddAWorkerToTheBrigade() => brigade.BrigadeListWorker = ListOfWorkers;
        public Brigade GetResult() => brigade;

        public static List<Worker> GerRandom(int QuanityRequest)
        {
            string[] WorkerName = { "Леша ", "Антон", "Влад ", "Витя ", "Саша ", "Вася ", "Петя ", "Костя", "Глеб " };
            string[] WorkerPost = { "ewdwed", "dwedew", "dwedew", "dwedew" };

            Random random = new Random();
            List<Worker> WorkerList = new List<Worker>();

            for (int i = 0; i < QuanityRequest; i++)
            {
                WorkerList.Add(
                    new Worker(
                        WorkerName[random.Next(0, QuanityRequest)],
                        WorkerPost[random.Next(0, 4)]
                        )
                    );
            }
            return WorkerList;
        }
    }
}
