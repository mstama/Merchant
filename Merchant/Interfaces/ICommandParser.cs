using Merchant.Models;

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
        /// <param name="text"></param>
        /// <returns></returns>
        Command Parse(string text);
    }
}