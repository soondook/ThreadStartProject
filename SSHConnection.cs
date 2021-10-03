using Newtonsoft.Json;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace ThreadStartProject
{


    class Action2
    {

        //public List<Person1> People { get; set; }
        public bool IsConnect { get; set; }
        public string Status { get; set; }
        public int ErrorCode { get; set; }
    }

    class SSH_Command
    {

        //public static string Connection(string host, int port, string pass)
        public static object Connection(string host, int port, string compassname)
        {
            string localPath;
            string localPath1 = "C:\\inetpub\\GoogleAuth\\wwwroot\\scripts\\";
            string localPath2 = "C:\\inetpub\\GoogleAuth\\wwwroot\\scripts\\";
            string source;
            string source1 = "fsum1.exe";
            string source2 = "fsum.exe";
            string root_destination;
            string root_destination1 = "/c/Protopas/Temp/";
            string root_destination2 = "/home/";
            string user = "Vladimir";
            var keyFile = new PrivateKeyFile(@"C:\cygwin64\home\OpenSSH\.ssh\rsa_new");
            var keyFiles = new[] { keyFile };
            var IsConnect = false;
            int ResultWorker = 1;
            string IsConnection = null;

            Task<string> sftPResult;
            PrivateKeyAuthenticationMethod method = new PrivateKeyAuthenticationMethod(user, keyFiles);
            ConnectionInfo con = new ConnectionInfo(host, port, user, method);
            //Set up the SSH connection
            using (SshClient client = new SshClient(con))
            {

                //Start the connection
                try
                {
                    client.Connect();
                    /*Console.WriteLine(client.IsConnected);
                    var output = client.RunCommand("pwd");
                    Console.WriteLine(output.Result);*/
                }
                catch (System.Net.Sockets.SocketException ex) { Console.WriteLine(ex.Message); IsConnection = "SSH Connection Error"; }
                catch (SshAuthenticationException ex) { Console.WriteLine(ex.Message); IsConnection = ex.Message.ToString(); }
                catch (SshConnectionException ex) { Console.WriteLine(ex.Message); IsConnection = ex.Message.ToString(); }
                catch (SshException ex) { Console.WriteLine(ex.Message); IsConnection = ex.Message.ToString(); }

                if (client.IsConnected)
                {
                    IsConnect = client.IsConnected;
                    var pathWithEnv = client.RunCommand("cd '" + root_destination1 + "'").ExitStatus;
                    Console.WriteLine("pathWithEnv: " + pathWithEnv);

                    if (pathWithEnv.Equals(0))
                    {
                        root_destination = root_destination1;
                        localPath = localPath1;
                        source = source1;
                        Console.WriteLine("root_destination " + root_destination);
                    }
                    else
                    {
                        root_destination = root_destination2;
                        localPath = localPath2;
                        source = source2;
                        Console.WriteLine("root_destination " + root_destination);
                    }

                    sftPResult = SftpConnectionAsync(root_destination, localPath, compassname, con, source);


                    Console.WriteLine("sFTP content: " + sftPResult.Result.ToString());
                    if (sftPResult.Result.ToString().StartsWith("RanToCompletion"))
                    {
                        ResultWorker = TicketWorker(root_destination, compassname, client, source);
                        Console.WriteLine("TicketWorker: " + ResultWorker);
                        IsConnection = sftPResult.Result.ToString();
                    }
                    client.Dispose();
                }

                else { }



                //return "IsConnect :" + IsConnect + "\n" + "sFTP content :" + sftPResult.Result.ToString();
                //List<Action> ActionData = new List<Action>() { };
                List<Action2> ActionData = new List<Action2> { new Action2() { IsConnect = IsConnect, Status = IsConnection, ErrorCode = ResultWorker } };
                //object newJsons2 = JsonConvert.SerializeObject(ActionData);
                object newAction = JsonConvert.SerializeObject(ActionData);
                return (newAction);

            }
        }
        public static async Task<string> SftpConnectionAsync(string root_destination, string localPath, string compassname, ConnectionInfo con, string source)
        {
            using (SftpClient client = new SftpClient(con))
            {
                client.Connect();
                List<Task> tasks = new List<Task>();
                var fileStream = new FileStream(localPath + source, FileMode.Open);
                string destination = root_destination + source;
                tasks.Add(UploadFileAsync(fileStream, destination, client, compassname, source));
                await Task.WhenAll(tasks).ConfigureAwait(true);
                client.Dispose();
                fileStream.Close();
                fileStream.Dispose();
                client.Dispose();
                return Task.CompletedTask.Status.ToString();
            }

            static async Task<bool> UploadFileAsync(FileStream fileStream, string destination, SftpClient client, string compassname, string source)
            {
                client.BufferSize = 4 * 1024;
                var task = Task.Factory.FromAsync(client.BeginUploadFile(fileStream, destination), client.EndUploadFile);
                await task.ConfigureAwait(true);
                //Console.WriteLine(task.IsCompleted.ToString());
                return task.IsCompleted;

            }

;
        }

        public static int TicketWorker(string root_destination, string compassname, SshClient client, string source)
        {

            int pathWithEnv;
            pathWithEnv = client.RunCommand("cd '" + root_destination + "'; chmod 777 '" + root_destination + source + "'").ExitStatus;
            pathWithEnv = client.RunCommand("exec '" + root_destination + source + "'").ExitStatus;
            //client.RunCommand("cd '" + root_destination + "'; rm " + source);
            client.RunCommand("cd '" + root_destination + "'");
            return pathWithEnv;

        }

    }
}
