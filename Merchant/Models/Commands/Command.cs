// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Interfaces;

namespace Merchant.Models
{
    /// <summary>
    /// Base class for commands
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Visit operation
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(ICommandVisitor visitor);
    }
}