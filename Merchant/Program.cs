using Merchant.Commands;
using Merchant.Converters;
using System;
using System.IO;

namespace Merchant
{
    class Program
    {
        private static CustomNumberConverter customNumberConverter = new CustomNumberConverter();
        private static RateConverter rateConverter = new RateConverter();
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
                switch (command)
                {
                    case MapCommand map:
                        customNumberConverter.AddMap(map.From, map.To);
                        break;
                    case RateCommand rate:
                        int amountValue = AmountToInt(rate.Amount);
                        rateConverter.AddRate(rate.Commodity, (double)rate.CreditValue / amountValue);
                        break;
                    case ManyQueryCommand many:
                        Console.WriteLine("{0} {1} is {2} Credits", many.Amount, many.Commodity, rateConverter.ToCredits(many.Commodity, AmountToInt(many.Amount)));
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
            return RomanNumberConverter.NumberToInteger(customNumberConverter.NumberToRoman(amount));
        }
    }
}