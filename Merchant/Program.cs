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
        private static ICommandParser _parser;
        private static readonly Queue<Command> _retry = new Queue<Command>();
        private static ICommandVisitor _visitor;

        // Composition root
        private static void Init()
        {
            _visitor = new CommandVisitor(new RateCalculator(), new MapTextConverter(), new RomanNumberConverter());
            _parser = new CommandRegexParser();
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
            if (!File.Exists(filePath)) { Console.WriteLine("File does not exist!"); }
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);

            foreach (var line in lines)
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