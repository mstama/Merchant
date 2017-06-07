using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for rate
    /// </summary>
    public class RateCommand : Command
    {
        public RateCommand(string commodity, string amount, int creditValue)
        {
            Commodity = commodity;
            Amount = amount;
            CreditValue = creditValue;
        }

        /// <summary>
        /// Amount in text
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Name of the commodity
        /// </summary>
        public string Commodity { get; set; }

        /// <summary>
        /// Value in credits
        /// </summary>
        public int CreditValue { get; set; }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} is {2} Credits", Amount, Commodity, CreditValue);
        }
    }
}