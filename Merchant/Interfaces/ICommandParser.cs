// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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