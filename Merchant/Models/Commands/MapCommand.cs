using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for text mapping
    /// </summary>
    public class MapCommand : Command
    {
        /// <summary>
        /// From text
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// To text
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MapCommand(string from, string to)
        {
            From = from;
            To = to;
        }

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