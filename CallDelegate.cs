using System;
using System.Collections.Generic;

namespace ThreadStartProject
{
    public delegate void MyDelegate();
    public delegate string Message(string v); // 1. Объявляем делегат
    public delegate string Action(string c);
    //public delegate List<string> Action(List<string> c);
    delegate List<string> Operation<T, K, F>(T vals, K val, F vall);
    delegate List<MyClass> TestDelegate(string arg1);



    public class CallDelegate
    {
        //public event MyDelegate Event;
        //public event Action EventAction;

        public static string[] vs = null;
        public static void Method()
        {
            string inputs = "JBSWY3DPEHPK3PXV";
            string v = "MethodV";

            Person person = new Person
            {
                Name = "Bob"
            };
            //подписываемся на событие DoWork;
            person.DoWork += Person_DoWork;
            person.GoToSleep += Person_GoToSleep;
            //вызываем метод TakeTime класса Person
            person.TakeTime(DateTime.Now);
            person.TakeTime(DateTime.Parse("08.01.2023 10:30:41"));
            //Console.WriteLine(DateTime.Now);


            //Message valueDelegate = DelegateClass.GenarateTOTP;
            //valueDelegate(inputs);
            
            Action action2 = DelegateClass.GenarateTOTP;
            action2(inputs);
            
            Message message1 = DelegateClass.GenarateTOTP;
            var mess = message1.Invoke(inputs);

            //List<MyClass> Method5(string arg1, string arg2);
            //var td1 = new TestDelegate<MyClass1>(Method5);

            TestDelegate test = Method5;
            var mmc = test(v);
            int i = 0;
            var myEnumerator = mmc.GetEnumerator();
            while ((myEnumerator.MoveNext()) && (myEnumerator.Current != null))
            {
                Console.WriteLine("[{0}] {1}", i++, myEnumerator.Current.GenericProperty);
            }            //mmc.ForEach(name => Console.WriteLine(name));
            //Console.WriteLine(mmc[1].GenericProperty);


            //-----------------------------
            object o = "";
            List<string> lists = new List<string>
            {
                v,
                mess
            };
            Operation<string, object, List<string>> operation = DelegateClass.Method1;
            operation += DelegateClass.Method7; // Добавляем в делегат вызов Method7   
            List<string> mm = operation?.Invoke(v, o, lists);
            mm.ForEach(name => Console.WriteLine(name));

            i = 0;
            var mEnumerator = mm.GetEnumerator();
            while ((mEnumerator.MoveNext()) && (mEnumerator.Current != null))
            {
                //Console.WriteLine("[{0}] {1}", i++, mEnumerator.Current);
            }                   

            //-------------------------------
            Console.Read();
            int k = 6;
            int s = 5;
            int SquareNumber(int n) => n * k;
            int result2 = Method3(6, s, SquareNumber);
            Console.WriteLine(result2);


            Func<int, int> func = Method4;
            func?.Invoke(6);
        }

        private static void Person_DoWork(object sender, EventArgs e)
        {
            Console.WriteLine($"{((Person)sender).Name} work");
        }

        private static string Person_GoToSleep(string c)
        {
            string j = "GoToSleep";
            Console.WriteLine(j);
            return j;
        }

        /// <summary>
        /// -------------------------------------------
        /// </summary>       


        public static int Method3(int n, int s, Func<int, int> operation)
        {
            int oper = operation(n * s);
            return oper;
        }

        public static int Method4(int s)
        {
            int oper = s;
            return oper;
        }

        public static List<MyClass> Method5(string s)
        {
            List<MyClass> list = new List<MyClass>() { };
            list.Add(new MyClass() { GenericProperty = "GenericProperty from Method5" });
            list.Add(new MyClass() { GenericProperty = "GenericProperty from Method6" });
            //new MyClass { GenericProperty = "GenericProperty from Method5" }
            return list;
        }
    }
}
