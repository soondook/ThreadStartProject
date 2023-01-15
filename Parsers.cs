using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    public static class Parsers
    {

        public static void RunParser(string args1)
        {
            foreach (var b in Blocks.Load("C:\\temp\\49E1749FDFAE3CC440D879AFC965F685A981C052.asc"))
            {
                //var str = b.Title + "\n\t" + string.Join("\n\t", b.Body);
                var str = b.Title;
                Console.WriteLine(str);
                System.Diagnostics.Trace.WriteLine(str);
            }
        }
    }

    class Blocks
    {
        public string Title;
        public List<string> Body;
        //Body.("BEGIN PGP PRIVATE KEY BLOCK");


        public static IEnumerable<Blocks> Load(string path)
        {

            Blocks ret = null;
            foreach (var line in File.ReadLines(path).Select(l => l.Trim()))
            {
                //Console.WriteLine(line);
                if (line.Length == 0 && ret != null)
                {
                    //Console.WriteLine("Length: "+line.Length + "ret :" +ret.Title);
                    //Console.WriteLine(ret.Title);
                    //yield return ret; //-- если раскоментить, будет ублировать последнюю строку (в блоке) в файле с пустыми разделителями!  
                    ret = null;
                    //continue; //--Раскомментировать для скрытия пробелов между блоками в файле с пустыми разделителями!
                }

                if (line.EndsWith(":"))
                {

                    ret = new Blocks { Title = line.TrimEnd(':'), Body = new List<string>() };
                    //Console.WriteLine(ret.Body);
                    continue; //---Закоментить для вывода заголовков с (:)
                }
                else
                {
                    ret = new Blocks { Title = line.TrimEnd(), Body = new List<string>() };

                }


                if (ret != null)
                    ret.Body.Add(line);
                yield return ret;
            }
        }
    }
}

