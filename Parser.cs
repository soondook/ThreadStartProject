using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace ThreadStartProject
{
    public class Parser
    {

        public static void RunParser(string args1)
        {
            foreach (var b in Block.Load("C:\\temp\\20220922.jrn"))
            {
                var str = b.Title + "\n\t" + string.Join("\n\t", b.Body);
                //var str = b.Title;
                Console.WriteLine(str);// + " Body: " + b.Body.FirstOrDefault());
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
        //foreach (var line in File.ReadLines(path).Select(l => l.Trim()))
        foreach (var line in File.ReadLines(path).Select(l => l.Replace(@"\s+", string.Empty)))
        {
            //Regex.Replace(line, @"\s+", string.Empty);
            //string.Concat(line.Where(c => !char.IsWhiteSpace(c)));
            if (line.Length == 0 && ret != null)
            {
                    //Console.WriteLine("line" + line);
                    //Console.WriteLine("Length: "+line.Length + "ret :" +ret.Title); // + " Body: " + ret.Body);
                    //yield return ret;
                    ret = null;
                    continue;
            }
                if (line.Contains("Rollb"))
                //if (line.Contains(":"))
                {
                    ret = new Block { Title = line.TrimEnd(), Body = new List<string>() };
                    //Console.WriteLine(line.);
                    //continue;
                }
                else
                {
                    //Console.WriteLine("line" + line);
                    //ret = new Block { Title = line.Trim(), Body = new List<string>() };
                    ret = new Block { Title = line.TrimEnd(), Body = new List<string>() };
                    //ret = null;
                    //Console.WriteLine(ret.Title);
                    continue;

                }  


            if (ret != null)
                ret.Body.Add(line);
                yield return ret;
        }
     }
  }
}
