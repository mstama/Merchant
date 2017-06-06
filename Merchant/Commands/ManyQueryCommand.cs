using Merchant.Interfaces;

namespace Merchant.Commands
{
    /// <summary>
    /// Command for how many questions
    /// </summary>
    public class ManyQueryCommand : Command
    {
        public ManyQueryCommand(string commodity, string amount)
        {
            Commodity = commodity;
            Amount = amount;
        }

        /// <summary>
        /// Amount in text
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Name of the commodity
        /// </summary>
        public string Commodity { get; set; }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return string.Format("How many Credits is {0} {1}", Amount, Commodity);
        }
    }
}