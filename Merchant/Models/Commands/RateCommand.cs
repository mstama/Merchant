using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for rate
    /// </summary>
    public class RateCommand : Command
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="alienValue"></param>
        /// <param name="creditValue"></param>
        public RateCommand(string commodity, string alienValue, int creditValue)
        {
            Commodity = commodity;
            Amount = alienValue;
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

        /// <summary>
        /// Run visitor method
        /// </summary>
        /// <param name="visitor"></param>
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