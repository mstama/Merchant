// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Null command
    /// </summary>
    public class NullCommand : Command
    {
        /// <summary>
        /// Do nothing with the visitor
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(ICommandVisitor visitor)
        {
            // Null object pattern
        }
    }
}