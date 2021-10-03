using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadStartProject
{
    public class Person1
    {

        public string State { get; set; }
        public string Ip { get; set; }
        public string CompassName { get; set; }
    }

    public class SFTPData
    {

        public string State { get; set; }
        public string Ip { get; set; }
        public string CompassName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string args1 = "new";
            Parser.RunParser(args1);
            // создаем новый поток
            //Thread myThread1 = new Thread(new ParameterizedThreadStart(Count1));
            //Thread myThread = new Thread(Count);
            //myThread.Start(); // запускаем поток
            //myThread1.Start(counter); // запускаем поток
            string connection_result="";
            List<SFTPData> sFTPDatas = new List<SFTPData>() { };
            string host = "ACER-Aspire";
            DBSQLServerUtils.ValidateDefaultInstancePostgreSqlServer(connection_result);
            string chk_res = DBSQLServerUtils.Connection2(host);
            Console.WriteLine(chk_res);
            JObject a = JObject.Parse(chk_res);
            JArray o = (JArray)a["key"];
            List<Person1> person1 = o.ToObject<List<Person1>>();
            for (int i = 0; i < person1.Count; i++)
            {
                var Compassname = person1[i].CompassName;
                var ip = person1[i].Ip;
                //Console.WriteLine(Compassname.ToString());
                Console.WriteLine(ip.ToString());
                sFTPDatas.AddRange(new List<SFTPData>() { new SFTPData() { Ip = person1[i].Ip } });
            }
            //int k = sFTPDatas.Count;

                for (int i = 0; i < sFTPDatas.Count; i++)
            {
                int f = i;
                int j = i;
                //object counter = new Counter();
                /*
                Counter counter = new Counter()
                {
                    x = f,
                    y = j,
                    t = i
                };
                */
                Merchant merch = new Merchant()

                {
                    IP = sFTPDatas[i].Ip,
                    CompassName = sFTPDatas[i].CompassName

                };

                //Thread myThread1 = new Thread(new ParameterizedThreadStart(Count1));
                Thread myThread1 = new Thread(new ParameterizedThreadStart(Count2));
                /*{
                    Name = "Поток " + i.ToString()
                };*/
                myThread1.Start(merch);
                //myThread1.Start(counter);
                Thread.Sleep(600);
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
           //int n = (int)x;
            //for (int i = 1; i < 9; i++)
            // {
                var j = c.x;
                var k = c.y;
                var m = c.t;
                //var chk_result = SSH_Command.Connection(IP, 22, CompassName);
                Console.WriteLine ("x_: {0} y_: {1} t_: {2} ", j, k, m);
               //Console.WriteLine("поток:{0} Значение: {1} itteration {2} ", c.t, ( c.x * c.y * i),  i);
                Console.WriteLine("поток:{0} Значение: {1} ", c.t, (c.x + c.y) * c.t);
                Thread.Sleep(400);
           // }
        }
        public static void Count2(object obj)
        {
            Merchant m = (Merchant)obj;
            //Counter c = (Counter)obj;
            //int n = (int)x;
            //for (int i = 1; i < 9; i++)
            // {
            //var j = c.x;
            //var k = c.y;
            //var n = c.t;
            SSH_Command.Connection(m.IP, 22, m.CompassName);
            //Console.WriteLine("x_: {0} y_: {1} t_: {2} ", j, k, n);
            //Console.WriteLine("поток:{0} Значение: {1} itteration {2} ", c.t, ( c.x * c.y * i),  i);
            //Console.WriteLine("поток:{0} Значение: {1} ", c.t, (c.x + c.y) * c.t);
            Thread.Sleep(400);
            // }
        }
        public class Counter
        {
            public int x = 4;
            public int y = 5;
            public int t;
        }


        public class Merchant
        {
            public string IP;
            public string CompassName;
            
        }

    }
}
