using Merchant.Interfaces;
using Merchant.Services;
using System;
using System.IO;

namespace Merchant
{
    internal class Program
    {
        private static ICommandParser _parser;
        private static ICommandVisitor _visitor;

        // Composition root
        private static void Init()
        {
            _visitor = new CommandVisitor(new RateCalculator(), new MapTextConverter(), new RomanNumberConverter());
            _parser = new CommandParser();
        }

        private static void Main(string[] args)
        {
            Init();
            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath)) Console.WriteLine("File does not exist!");
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);

            foreach (var line in lines)
            {
                var command = _parser.Parse(line);
                command.Accept(_visitor);
            }
        }
    }
}