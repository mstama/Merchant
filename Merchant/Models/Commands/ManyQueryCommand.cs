﻿// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Command for how many questions
    /// </summary>
    public class ManyQueryCommand : Command
    {
        /// <summary>
        /// Alien value
        /// </summary>
        public string AlienValue { get; set; }

        /// <summary>
        /// Name of the commodity
        /// </summary>
        public string Commodity { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commodity">Name of commodity</param>
        /// <param name="alienValue">Alien value</param>
        public ManyQueryCommand(string commodity, string alienValue)
        {
            Commodity = commodity;
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
            return string.Format("How many Credits is {0} {1}", AlienValue, Commodity);
        }
    }
}