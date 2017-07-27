// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;
using Merchant.Models;
using System;

namespace Merchant.Services
{
    /// <summary>
    /// Command Visitor implementation
    /// </summary>
    public class CommandVisitor : ICommandVisitor
    {
        private readonly IRateCalculator _calculator;
        private readonly IMapConverter<string, string> _mapConverter;
        private readonly IConverter<string, int> _romanConverter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="mapConverter"></param>
        /// <param name="romanConverter"></param>
        public CommandVisitor(IRateCalculator calculator, IMapConverter<string, string> mapConverter, IConverter<string, int> romanConverter)
        {
            _calculator = calculator;
            _mapConverter = mapConverter;
            _romanConverter = romanConverter;
        }

        /// <summary>
        /// Visit the ManyQueryCommand
        /// </summary>
        /// <param name="command"></param>
        public void Visit(ManyQueryCommand command)
        {
            Console.WriteLine("{0} {1} is {2} Credits", command.AlienValue, command.Commodity, _calculator.ToCredits(command.Commodity, AlienValueToValue(command.AlienValue)));
        }

        /// <summary>
        /// Visit the MapCommand
        /// </summary>
        /// <param name="command"></param>
        public void Visit(MapCommand command)
        {
            _mapConverter.AddMap(command.From, command.To);
        }

        /// <summary>
        /// Visit the MuchQueryCommand
        /// </summary>
        /// <param name="command"></param>
        public void Visit(MuchQueryCommand command)
        {
            Console.WriteLine("{0} is {1}", command.AlienValue, AlienValueToValue(command.AlienValue));
        }

        /// <summary>
        /// Visit the RateCommand
        /// </summary>
        /// <param name="command"></param>
        public void Visit(RateCommand command)
        {
            int amountValue = AlienValueToValue(command.Amount);
            _calculator.AddRate(command.Commodity, (double)command.CreditValue / amountValue);
        }

        /// <summary>
        /// Visit the UnknownCommand
        /// </summary>
        /// <param name="command"></param>
        public void Visit(UnknownCommand command)
        {
            Console.WriteLine("I have no idea what you are talking about");
        }

        /// <summary>
        /// Convert alien value to human value
        /// </summary>
        /// <param name="alienValue"></param>
        /// <returns></returns>
        private int AlienValueToValue(string alienValue)
        {
            return _romanConverter.Convert(_mapConverter.Convert(alienValue));
        }
    }
}