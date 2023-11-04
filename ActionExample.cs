using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    public static class ActionExample
    {
        private static readonly List<string> _names = new List<string>();
        //private delegate void myDelegate(string s);

        private static void AddName(string name)
        {
            _names.Add(name);
        }

        public static void Run()
        {
            // The delegate equivalent just uses void instead of string.
            static void actionMethod1(string name) => _names.Add(name);
            static void actionMethod2(string name) { _names.Add(name); }

            Action<string> actionMethod3 = AddName;
            actionMethod1("bob");
            actionMethod2("jon");
            actionMethod3("fred");

            _names.ForEach(name => Console.WriteLine(name));

            Console.ReadLine();
        }
    }
}
