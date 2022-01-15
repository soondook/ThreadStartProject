using OtpNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadStartProject
{
    class OTP
    {

        public static string GenarateTOTP()
        {
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
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
    }
}
