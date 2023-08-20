using System;
using OtpNet;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
        
    public static class DelegateClass
    {

        public static string GenarateTOTP(string inputs)
        {
            var bytes = Base32Encoding.ToBytes(inputs);
            var window = new VerificationWindow(previous: 1, future: 1);
            var totp = new Totp(bytes, step: 300);

            var result = totp.ComputeTotp(DateTime.UtcNow);

            Console.WriteLine(result);

            //var input = Console.ReadLine();
            //bool verify = totp.VerifyTotp(input, out long timeStepMatched, window);

            //Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            //Console.WriteLine("{0}-:{1}", "verify", verify);
            return result;
        }

        public static string VerifyTOTP(string inputs)
        {
            var bytes = Base32Encoding.ToBytes(inputs);
            var window = new VerificationWindow(previous: 1, future: 1);
            var totp = new Totp(bytes, step: 300);
            
            var input = Console.ReadLine();
            bool verify = totp.VerifyTotp(input, out long timeStepMatched, window);

            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
            return verify.ToString();
        }

        public static List<string> Method1(string v, object o, List<string> lists)
        {
            //Console.WriteLine(v);
            string s = "Method1_invoke_Method1";
            lists.Add(v);
            lists.Add(s);
            lists.Add((string)o);

            //Console.WriteLine(lists.ForEach());
            //vs = list.ToArray();
            //lists.ForEach(name => Console.WriteLine(name));
            return lists;
        }

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

        public static List<MyClass> Method5(string v)
        {
            List<MyClass> list = new List<MyClass>() { };
            list.Add(new MyClass() { GenericProperty = v });
            list.Add(new MyClass() { GenericProperty = v+"1" });
            //new MyClass { GenericProperty = "GenericProperty from Method5" }
            return list;
        }
        public static List<string> Method7(string v, object o, List<string> lists)
        {
            //Console.WriteLine(v);
            string s = "Operational7";
            lists.Add(s);
            //Console.WriteLine(lists.ForEach());
            //vs = list.ToArray();
            //lists.ForEach(name => Console.WriteLine(name));
            return lists;
        }


    }
}
