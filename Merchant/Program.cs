using Merchant.Exceptions;
using Merchant.Extensions;
using Merchant.Interfaces;
using Merchant.Models;
using Merchant.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Merchant
{
    internal static class Program
    {
        private static readonly ICommandParser _parser;
        private static readonly Queue<Command> _retry = new Queue<Command>();
        private static readonly ICommandVisitor _visitor;

        // Composition root
        static Program()
        {
            _visitor = new CommandVisitor(new RateCalculator(), new MapTextConverter(), new RomanNumberConverter());
            _parser = new CommandRegexParser();
        }

        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath)) { Console.WriteLine("File does not exist!"); }
            Console.WriteLine("Processing file {0}.", args[0]);

            foreach (var line in File.ReadLines(filePath))
            {
                var command = _parser.Parse(line);
                try
                {
                    command.Accept(_visitor);
                }
                catch (MerchantException) // Known exception
                {
                    _retry.Enqueue(command);
                }
            }

            while (_retry.NotEmpty())
            {
                var command = _retry.Dequeue();
                command.Accept(_visitor);
            }
        }
    }
}