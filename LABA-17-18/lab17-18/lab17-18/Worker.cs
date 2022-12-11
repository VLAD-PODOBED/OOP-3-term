using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
	internal class Worker
	{
		private static int CountWorker = 0;
		public string NameWorker { get; set; }
		public string Post { get; set; }
		public int WorkerID { get; set; } = 0;

		protected static List<Worker> workers = new List<Worker>();


		public Worker(string NameWorker, string Post)
		{
			CountWorker++;
			this.Post = Post;
			this.NameWorker = NameWorker;
        }
		public Worker(string NameWorker, string Post, int CountWorker)
		{
			WorkerID = CountWorker;
            workers.Add(new Worker(NameWorker, Post, CountWorker));
		}
    }
}
