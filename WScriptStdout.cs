using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ThreadStartProject
{

    public static class WScriptStdout
    {

        public static void RunParsers(string args1)
        {
            Console.WriteLine("go1");
            foreach (var b in Blocks1.RStdout("C:\\temp\\49E1749FDFAE3CC440D879AFC965F685A981C052.asc"))
            {
                //Blocks1.RStdout(args1);
                var str = b.Title.ToString();
                Console.WriteLine(str + "RStdout" + b.Body.FirstOrDefault());
                //System.Diagnostics.Trace.WriteLine(str);
            }
        }
    }


    public class Blocks1
    {
        
        public string Title;
        public List<string> Body;
        public static IEnumerable<Blocks1> RStdout(string path)
        {
            Console.WriteLine("go2");
            Blocks1 ret = null;
            //bool exit = false;
            var p = new Process()
            {
                StartInfo = new ProcessStartInfo("C:\\Windows\\System32\\ipconfig.exe")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                }
            };

            var outputWriter = new StringWriter();
            //p.OutputDataReceived += (sender, args) => outputWriter.WriteLine(args.Data);

            var errorWriter = new StringWriter();
            //p.ErrorDataReceived += (sender, args) => errorWriter.WriteLine(args.Data);
            Console.WriteLine("go");
            p.Start();
            //p.BeginOutputReadLine();
            //p.BeginErrorReadLine();
            //p.WaitForExit();

            //Console.WriteLine(p.StandardOutput.ReadLine().ToString());

            while (!p.StandardOutput.EndOfStream)
            {
                //Console.WriteLine(p.StandardOutput.ReadLine().ToString());


                //if (p.StandardOutput.ReadLine().Length != 0)
                //{
                //p.OutputDataReceived += (sender, args) => outputWriter.WriteLine(args.Data);

                

                if (p.StandardOutput.ReadLine().Length != 0 )
                //if (p.StandardOutput.ReadLine().Contains("255"))
                {

                    //ret = null;
                    try { 
                    ret = new Blocks1 { Title = p.StandardOutput.ReadLine().TrimEnd(), Body = new List<string>() };
                    }
                    catch { }
                    //ret = p.StandardOutput.ReadLine().ToString();

                    //Console.WriteLine(p.StandardOutput.ReadLineAsync().Result);
                    //Console.WriteLine(p.StandardOutput.ReadLine().ToString() + "break");
                    //Console.WriteLine("break");
                    //exit = true;
                    //break;
                    yield return ret;
                    //Console.WriteLine(ret.Title);
                }
                       
                //}
                
            }
            ret?.Body.Add(p.StandardOutput.ReadLine());
            yield return ret;
        }
    }
}
