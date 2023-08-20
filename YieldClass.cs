using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadStartProject
{
    public static class YieldClass
    {

        public static IEnumerable<int> GenerateHugeSequenceLazy()
        {
            for (int i = 0; i < 1000000; i++)
                yield return 13 * i;
        }

        public static IEnumerable<int> GenerateHugeSequenceEager()
        {
            var result = new List<int>();
            for (int i = 0; i < 1000000; i++)
                result.Add(13 * i);
            return result;
        }

        public static void Lazy()
        {

            var seqLazy = GenerateHugeSequenceLazy();
            // вычисляем максимум вручную
            var max = 0;
            foreach (var v in seqLazy)
                if (v > max)
                    max = v;

            var memLazy = GC.GetTotalMemory(forceFullCollection: false);       

           

            var seqEager = GenerateHugeSequenceEager();
            // вычисляем максимум вручную
            max = 0;
            foreach (var v in seqEager)
                if (v > max)
                    max = v;

            var memEager = GC.GetTotalMemory(forceFullCollection: false);

            Console.WriteLine($"Memory footprint lazy: {memLazy}, eager: {memEager}");
        }

        
    }


    public static class YieldClass2
    {

        public static IEnumerable<int> Eager10()
        {
            Console.WriteLine("Eager");
            int counter = 0;
            try
            {
                var result = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Adding: {i}");
                    counter++;
                    result.Add(i);
                }
                return result;
            }
            finally
            {
                Console.WriteLine($"Eagerly computed: {counter}");
            }
        }

        public static IEnumerable<int> Lazy10()
        {
            Console.WriteLine("Lazy");
            int counter = 0;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Adding: {i}");
                    counter++;
                    yield return i;
                }
            }
            finally
            {
                Console.WriteLine($"Lazily computed: {counter}");
            }
        }


        public static void ResultElder()
        {

            foreach (var e in Eager10().Take(2))
                Console.WriteLine($"EagerObtained: {e}");

            foreach (var e in Lazy10().Take(2))
                Console.WriteLine($"LazyObtained: {e}");

            foreach (var e in Lazy10())
            {
                Console.WriteLine($"LazyObtained2: {e}");
                if (e == 1)
                    break;
            }

        }

    }



    
}
