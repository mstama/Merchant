using Merchant.Commands;

namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the command parsers
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Parse the text to return a command
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Command Parse(string value);
    }
}