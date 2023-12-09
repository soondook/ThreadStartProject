using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStartProject
{
    internal class Banana<T> : Product<T>
    {
        public Banana(string name, T volume, T energy) : base(name, volume, energy)
        {
        }
    }
}
