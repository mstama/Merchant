using Merchant.Interfaces;

namespace Merchant.Commands
{
    /// <summary>
    /// Command for unknown
    /// </summary>
    public class UnknownCommand : Command
    {
        public UnknownCommand(string value)
        {
            Text = value;
        }

        /// <summary>
        /// Command text found
        /// </summary>
        public string Text { get; set; }

        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}