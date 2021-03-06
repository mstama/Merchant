﻿// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Extensions;
using Merchant.Interfaces;
using Merchant.Models;
using System;
using System.Linq;

namespace Merchant.Services
{
    /// <summary>
    /// Parse the text commands
    /// </summary>
    public class CommandParser : ICommandParser
    {
        private const StringComparison _comparer = StringComparison.OrdinalIgnoreCase;
        private static readonly char[] _separator = { ' ' };

        /// <summary>
        /// Parse the text and returns a command
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Command Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return new NullCommand(); }

            var words = text.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            //It is a query
            if (text.Contains("?", _comparer))
            {
                if (text.Contains("HOW MUCH IS ", _comparer))
                {
                    string amount = string.Join(" ", words.Skip(3).Take(words.Length - 4));
                    return new MuchQueryCommand(amount);
                }
                if (text.Contains("HOW MANY CREDITS IS ", _comparer))
                {
                    string commodity = words[words.Length - 2];
                    string amount = string.Join(" ", words.Skip(4).Take(words.Length - 6));
                    return new ManyQueryCommand(commodity, amount);
                }
            }
            else //Its a Mapping-Rate
            {
                // Rate
                if (text.Contains("CREDITS", _comparer))
                {
                    int credit = int.Parse(words[words.Length - 2]);
                    string commodity = words[words.Length - 4];
                    string amount = string.Join(" ", words.Take(words.Length - 4));
                    return new RateCommand(commodity, amount, credit);
                }
                else
                {
                    return new MapCommand(words[0], words[2]);
                }
            }
            return new UnknownCommand(text);
        }
    }
}