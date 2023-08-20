using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadStartProject
{
    internal class SplitClass
    {
        public static void SSplit(string s)
        {
            //string s;
            string v = null;
            string[] newstr;
            Console.WriteLine("Enter the email addresses: ");
            //s = "Україна,область Дніпропетровська,місто Дніпро,вулиця Набережна Перемоги,будинок 32 в 0 м від Вас";
            newstr = s.Split(new char[] { ',' }); // Split to get a temporal array of addresses 
            var ele = newstr.Skip(2);
            foreach (var str in ele)
            {
                //Console.WriteLine (str);
                v += str + ", ";
            }
            v = v.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine(v);
            //newstr = s.Split(new char[] { ',', ';' }).Skip(1);
            //Console.WriteLine(s.Substring(s.IndexOf(','))); // Extract the sender from the email addresses
            //Console.WriteLine(s.Split(',').Skip(1));

            string st = "Україна,область Дніпропетровська,місто Дніпро,вулиця Набережна Перемоги,будинок 32 в 0 м від Вас";

            Console.WriteLine(string.Join(",", st.Split(',').Skip(2)));

        }
    }
}
