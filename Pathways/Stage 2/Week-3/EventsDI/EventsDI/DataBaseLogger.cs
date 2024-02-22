using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDI
{
    public class DataBaseLogger: ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Using the Log method of the DataBaseLogger");
            LogToDatabase(message);
        }

        public void LogToDatabase(string message)
        {
            Console.WriteLine($"Method: LogToDatabase, Test: {message}\n");
        }
    }
}
