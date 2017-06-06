using Merchant.Interfaces;

namespace Merchant.Commands
{
    /// <summary>
    /// Command for how much questions
    /// </summary>
    public class MuchQueryCommand : Command
    {
        public MuchQueryCommand(string amount)
        {
            Amount = amount;
        }

        /// <summary>
        /// Amount in text
        /// </summary>
        public string Amount { get; set; }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return string.Format("How much is {0}?", Amount);
        }
    }
}