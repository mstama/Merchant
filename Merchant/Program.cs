using System;
using System.IO;

namespace Merchant
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) Console.WriteLine("Input file required!");
            string filePath = args[0];
            if (!File.Exists(filePath)) Console.WriteLine("File does not exist!");
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                var command = CommandParser.Parse(line);
                Console.WriteLine(command);
            }

            Console.ReadLine();
        }
    }
}