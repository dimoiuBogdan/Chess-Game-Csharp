using System;
using System.IO;

namespace ChessGame
{
    public class Logger
    {
        public static void Log(Exception ex)
        {
            Console.Write("\r\nLog Entry : ");
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            Console.WriteLine($"  :{ex.Message}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"  :{ex.StackTrace}");

        }
    }
}
