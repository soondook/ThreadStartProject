﻿using System;
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


            for (int i = 0; i < 500; i++)
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
                //myThread1.Start(counter);
            }
            string args1 = "new";
            Parser.RunParser(args1);
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
            //for (int i = 1; i < 9; i++)
            // {
                var j = c.x;
                var k = c.y;
                var m = c.t;
                Console.WriteLine ("x_: {0} y_: {1} t_: {2} ", j, k, m);
               //Console.WriteLine("поток:{0} Значение: {1} itteration {2} ", c.t, ( c.x * c.y * i),  i);
                 Console.WriteLine("поток:{0} Значение: {1} ", c.t, (c.x + c.y) * c.t);
                 Thread.Sleep(400);
           // }
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
