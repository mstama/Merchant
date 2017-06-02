using Merchant.Commands;
using Merchant.Converters;
using Merchant.Interfaces;
using System;
using System.IO;

namespace Merchant
{
    class Program
    {
        private static IMapConverter<string, string> mapConverter;
        private static IRateCalculator calculator;
        private static IConverter<string, int> romanConverter;
        private static ICommandParser parser;

        // Composition root
        static void Init()
        {
            calculator = new RateCalculator();
            mapConverter = new MapTextConverter();
            romanConverter = new RomanNumberConverter();
            parser = new CommandParser();
        }

        static void Main(string[] args)
        {
            Init();
            if (args.Length == 0) Console.WriteLine("Input file required!");
            string filePath = args[0];
            if (!File.Exists(filePath)) Console.WriteLine("File does not exist!");
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);
            
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                var command = parser.Parse(line);
                switch (command)
                {
                    case MapCommand map:
                        mapConverter.AddMap(map.From, map.To);
                        break;
                    case RateCommand rate:
                        int amountValue = AmountToInt(rate.Amount);
                        calculator.AddRate(rate.Commodity, (double)rate.CreditValue / amountValue);
                        break;
                    case ManyQueryCommand many:
                        Console.WriteLine("{0} {1} is {2} Credits", many.Amount, many.Commodity, calculator.ToCredits(many.Commodity, AmountToInt(many.Amount)));
                        break;
                    case MuchQueryCommand much:
                        Console.WriteLine("{0} is {1}", much.Amount, AmountToInt(much.Amount));
                        break;
                    default:
                        Console.WriteLine("I have no idea what you are talking about");
                        break;
                }
            }

            Console.ReadLine();
        }

        private static int AmountToInt(string amount)
        {
            return romanConverter.Convert(mapConverter.Convert(amount));
        }
    }
}