// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for unknown
    /// </summary>
    public class UnknownCommand : Command
    {
        /// <summary>
        /// Command text found
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public UnknownCommand(string value)
        {
            Text = value;
        }

        /// <summary>
        /// Run visitor method
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(ICommandVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}