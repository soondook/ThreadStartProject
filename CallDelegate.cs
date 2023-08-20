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
        public static string[] vs = null;
        public static void Method()
        {
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

        }

        public static void MethodOTP()
        {
            string inputs = "JBSWY3DPEHPK3PXV";
           
            Action action2 = DelegateClass.GenarateTOTP;
            action2(inputs);

            Message message1 = DelegateClass.VerifyTOTP;
            var mess = message1.Invoke(inputs);
            Console.WriteLine("mess: "+ mess);

        }

        public static void Method5()
        {            
            string v = "MethodV";
            TestDelegate test = DelegateClass.Method5;
            var mmc = test(v);
            
            mmc.ForEach(name => Console.WriteLine(name.GenericProperty));
            /*
            int i = 0;
            var myEnumerator = mmc.GetEnumerator();
            while ((myEnumerator.MoveNext()) && (myEnumerator.Current != null))
            {
                Console.WriteLine("[{0}] {1}", i++, myEnumerator.Current.GenericProperty);
            }            mmc.ForEach(name => Console.WriteLine(name));
                         Console.WriteLine(mmc[1].GenericProperty);
            */
        }

        //-----------------------------
        public static void Method7() {

            string inputs = "JBSWY3DPEHPK3PXV";
            string v = "Method1";
            string j = "Method1_list";
            object o = "object, object1";
            List<string> lists = new List<string>
            {
                j,
                inputs
            };
            Operation<string, object, List<string>> operation = DelegateClass.Method1;
            operation += DelegateClass.Method7; // Добавляем в делегат вызов Method7   
            List<string> mm = operation?.Invoke(v, o, lists);
            mm.ForEach(name => Console.WriteLine(name));
            /*
            int i = 0;
            var mEnumerator = mm.GetEnumerator();
            while ((mEnumerator.MoveNext()) && (mEnumerator.Current != null))
            {
                Console.WriteLine("[{0}] {1}", i++, mEnumerator.Current);
            }                   
            */
            //-------------------------------
            Console.Read();
            int k = 6;
            int s = 5;
            int SquareNumber(int n) => n * k;
            int result2 = DelegateClass.Method3(3, s, SquareNumber);
            Console.WriteLine(result2);


            Func<int, int> func = DelegateClass.Method4;
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


        
    }
}
