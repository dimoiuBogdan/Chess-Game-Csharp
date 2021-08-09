using System;
using System.IO;

namespace ChessGame
{
    public class Logger
    {
        public static void Log(string message, string stackTrace)
        {
            Console.Write("\r\nLog Entry : ");
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            Console.WriteLine("  :");
            Console.WriteLine($"  :{message}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"  :{stackTrace}");

        }
    }
}
