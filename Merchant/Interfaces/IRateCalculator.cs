// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the rate calculator
    /// </summary>
    public interface IRateCalculator
    {
        /// <summary>
        /// Register commodity rate in credits
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="rate"></param>
        void AddRate(string commodity, double rate);

        /// <summary>
        /// Calculate in credits the value of the commodity
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        double ToCredits(string commodity, int amount);
    }
}