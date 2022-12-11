using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    interface IWorkerBuilder
    {
        void AddAWorkerToTheBrigade();
        Brigade GetResult();
    }
}
