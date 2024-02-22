using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDI
{
    public class PapyrusLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Using the Log method of the PapyrusLogger");
            LogToPapyrus(message);
        }

        public void LogToPapyrus(string message)
        {
            Console.WriteLine($"Method: LogToPapyrus, Test: {message}\n");
        }
    }
}