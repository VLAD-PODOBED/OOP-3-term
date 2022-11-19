using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop7
{
    interface IGeneric<T>
    {
        void Add(T dt);
        void Delete(T dt);
        void Show();
    }
}