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

            var input = Console.ReadLine();
            bool verify = totp.VerifyTotp(input, out long timeStepMatched, window);

            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
            return result;
        }

        public static List<string> Method1(string v, object o, List<string> lists)
        {
            //Console.WriteLine(v);
            string s = "Operational";
            lists.Add(s);
            //Console.WriteLine(lists.ForEach());
            //vs = list.ToArray();
            //lists.ForEach(name => Console.WriteLine(name));
            return lists;
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
