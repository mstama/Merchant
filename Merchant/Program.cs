﻿using Merchant.Exceptions;
using Merchant.Interfaces;
using Merchant.Models;
using Merchant.Services;
using System;
using System.Collections.Generic;
using System.IO;
using Merchant.Extensions;

namespace Merchant
{
    internal class Program
    {
        private static ICommandParser _parser;
        private static ICommandVisitor _visitor;
        private static Queue<Command> _retry = new Queue<Command>();

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
            if (!File.Exists(filePath)) Console.WriteLine("File does not exist!");
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);

            foreach (var line in lines)
            {
                var command = _parser.Parse(line);
                try
                {
                    command.Accept(_visitor);
                }
                catch (MerchantException)
                {
                    _retry.Enqueue(command);
                }
            }

            while (_retry.NotEmpty())
            {
                var command = _retry.Dequeue();
                try
                {
                    command.Accept(_visitor);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.ReadLine();
        }
    }
}