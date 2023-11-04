using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    public static class DateTool
    {
        public static DateTime Min(DateTime x, DateTime y)
        {
            return (x.ToUniversalTime() < y.ToUniversalTime()) ? x : y;
        }
        public static DateTime Max(DateTime x, DateTime y)
        {
            return (x.ToUniversalTime() > y.ToUniversalTime()) ? x : y;
        }



        public static DateTime Randomdayfunc()
        {
            DateTime start = new DateTime(1995, 1, 1);
            var gen = new Random();
            int range = (DateTime.Today - start).Days;
            var dt =  start.AddDays(gen.Next(range));
            Console.WriteLine("RandomDate: {0}", dt);
            return dt;
        }
    }
}
