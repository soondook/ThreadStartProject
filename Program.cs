using System;
using System.Threading;

namespace ThreadStartProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем новый поток
            

            //Thread myThread1 = new Thread(new ParameterizedThreadStart(Count1));
            //Thread myThread = new Thread(Count);
            //myThread.Start(); // запускаем поток
            //myThread1.Start(counter); // запускаем поток


            for (int i = 0; i < 5; i++)
            {
                int f = i;
                int j = i;

                Counter counter = new Counter
                {
                    x = f,
                    y = j,
                    t = i
                };

                Thread myThread1 = new Thread(new ParameterizedThreadStart(Count1));
                myThread1.Name = "Поток " + i.ToString();
                myThread1.Start(counter);
            }
            /*
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток: {0}",  i* i);
                //Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
            */
            Console.ReadLine();
        }

        public static void Count1(object obj)
        {
            Counter c = (Counter)obj;
            for (int i = 1; i < 9; i++)
            {
                
                
                //Console.WriteLine(i);
                Console.WriteLine("{1} поток: {0} itteration {2} ", ( c.x * c.y), c.t, i);
                Thread.Sleep(400);
            }
        }
        /*
        public static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Третий поток:" + i * i);
                //Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }
        */
        public class Counter
        {
            public int x = 4;
            public int y = 5;
            public int t;
        }

    }
}
