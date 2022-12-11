using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Director
    {
        private readonly IWorkerBuilder builder;
        public Director(IWorkerBuilder builder) => this.builder = builder;
        public void Build() => builder.AddAWorkerToTheBrigade();
    }
}
