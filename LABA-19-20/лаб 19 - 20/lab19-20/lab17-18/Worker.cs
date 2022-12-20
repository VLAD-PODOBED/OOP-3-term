using lab17_18;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    interface IMovable  // Strategy
    {
        void Move();
    }
    internal class Worker : IMovable
	{
		public static int CountWorker = 0;
		public string NameWorker { get; set; }
		public string Post { get; set; }
		public int WorkerID { get; set; } = 0;

		protected static List<Worker> workers = new List<Worker>();


        public IMovable Movable { private get; set; } 

        public Worker(string NameWorker, string Post, IMovable Movable)
		{
			CountWorker++;
			this.Post = Post;
            this.Movable = Movable;
            this.NameWorker = NameWorker;
        }
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
        public void Move()
        {
            Movable.Move();
        }
    }
    class JobHunting : IMovable
    {
        public void Move() => Console.WriteLine("Я без подписки , дайте её пожалуйста  ");
    }

    class GoodJob : IMovable
    {
        public void Move() => Console.WriteLine("Я нашел книгу для подписки ");
    }
}
