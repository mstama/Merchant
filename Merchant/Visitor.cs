using Merchant.Commands;
using Merchant.Interfaces;
using System;

namespace Merchant
{
    public class Visitor : IVisitor
    {
        private IRateCalculator _calculator;
        private IMapConverter<string, string> _mapConverter;
        private IConverter<string, int> _romanConverter;

        public Visitor(IRateCalculator calculator, IMapConverter<string, string> mapConverter, IConverter<string, int> romanConverter)
        {
            _calculator = calculator;
            _mapConverter = mapConverter;
            _romanConverter = romanConverter;
        }

        public void Visit(ManyQueryCommand command)
        {
            Console.WriteLine("{0} {1} is {2} Credits", command.Amount, command.Commodity, _calculator.ToCredits(command.Commodity, AmountToInt(command.Amount)));
        }

        public void Visit(MapCommand command)
        {
            _mapConverter.AddMap(command.From, command.To);
        }

        public void Visit(MuchQueryCommand command)
        {
            Console.WriteLine("{0} is {1}", command.Amount, AmountToInt(command.Amount));
        }

        public void Visit(RateCommand command)
        {
            int amountValue = AmountToInt(command.Amount);
            _calculator.AddRate(command.Commodity, (double)command.CreditValue / amountValue);
        }

        public void Visit(UnknownCommand command)
        {
            Console.WriteLine("I have no idea what you are talking about");
        }

        private int AmountToInt(string amount)
        {
            return _romanConverter.Convert(_mapConverter.Convert(amount));
        }
    }
}