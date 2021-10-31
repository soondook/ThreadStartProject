using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    public class Parser
    {

        public static void RunParser(string args1)
        {
            foreach (var b in Block.Load("C:\\temp\\49E1749FDFAE3CC440D879AFC965F685A981C052.asc"))
            {
                 //var str = b.Title + "\n\t" + string.Join("\n\t", b.Body);
                var str = b.Title;
                Console.WriteLine(str);
                System.Diagnostics.Trace.WriteLine(str);
            }
        }
    }

class Block
{
   public string Title;
   public IList<string> Body;
   //Body.("BEGIN PGP PRIVATE KEY BLOCK");
   

    public static IEnumerable<Block> Load(string path)
    {
            
        Block ret = null;
        foreach (var line in File.ReadLines(path).Select(l => l.Trim()))
        {
            //Console.WriteLine(line);
            if (line.Length != 0 && ret != null)
            {
                //Console.WriteLine(line);
                //yield return ret;
                ret = null;
                //continue;
            }

                if (line.EndsWith(":"))
                {

                    ret = new Block { Title = line.TrimEnd(':'), Body = new List<string>() };
                    //Console.WriteLine(ret.Body);
                    continue;
                }
                else
                {
                    ret = new Block { Title = line.TrimEnd(), Body = new List<string>() };
                    
                }  


            if (ret != null)
                ret.Body.Add(line);
                yield return ret;
            }
    }
  }
}
