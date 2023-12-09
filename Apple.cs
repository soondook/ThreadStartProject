using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStartProject
{
    public class Apple<T> : Product1<T>
    {
        public Apple(T volume, T energy) : base(volume, energy)
        {
        }

        
    }
}
