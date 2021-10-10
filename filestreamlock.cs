using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ThreadStartProject
{
    class Filestreamlock
    {
        public static bool IsFileLocked(string filePath, int secondsToWait)
        {
            bool isLocked = true;
            int i = 0;

            while (isLocked && ((i < secondsToWait) || (secondsToWait == 0)))
            {
                try
                {
                    //using (File.Open(filePath, FileMode.Open)) { }
                    using var fileStream = new FileStream(filePath, FileMode.Open);
                    fileStream.Close();
                    fileStream.Dispose();
                    return false;
                }
                catch (IOException e)
                {
                    var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
                    isLocked = errorCode == 32 || errorCode == 33;
                    i++;

                    if (secondsToWait != 0)
                        new System.Threading.ManualResetEvent(false).WaitOne(10);
                }
            }

            return isLocked;
        }
    }
}
