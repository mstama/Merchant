// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for how much questions
    /// </summary>
    public class MuchQueryCommand : Command
    {
        /// <summary>
        /// Alien value
        /// </summary>
        public string AlienValue { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="alienValue"></param>
        public MuchQueryCommand(string alienValue)
        {
            AlienValue = alienValue;
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
            return string.Format("How much is {0}?", AlienValue);
        }
    }
}