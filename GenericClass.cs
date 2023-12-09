using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    public class Product<T>
    {
        public  string Name { get; set; }
        public  T Volume { get; set; }
        public T Energy { get; set; }

        //public int MyProperty { get; set; }

        public Product(string name, T volume, T energy)
        { 
          // TODO: проверить входные параметры

           Name = name;
           Volume = volume;
           Energy = energy;            
        }

        //Add();
        public int Add(int volume)
        {

            int pp = volume * 10;
            Console.WriteLine(pp);
            return pp;
        }

    }

    
}
