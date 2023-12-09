using System;
using System.Xml.Linq;


namespace ThreadStartProject
{
    public class Eating<T>: Product1<T>
           //where T : Product1<int>
    {
        public Eating(T volume, T energy) : base(volume, energy)
        {
        }

        public void Add1 (T volume, T energy)
        {

            //var pp = product.Volume;
            int pp = Volume;
            int pp1 = Energy
            Console.WriteLine(pp.ToString());

        }
    }
}
