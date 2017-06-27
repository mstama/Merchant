using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for text mapping
    /// </summary>
    public class MapCommand : Command
    {
        public MapCommand(string from, string to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// From text
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// To text
        /// </summary>
        public string To { get; set; }

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
            return string.Format("{0} is {1}", From, To);
        }
    }
}