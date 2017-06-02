using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Interfaces
{
    /// <summary>
    /// Interface for the rate calculator
    /// </summary>
    public interface IRateCalculator
    {
        /// <summary>
        /// Calculate in credits the value of the commodity
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        double ToCredits(string commodity, int amount);

        /// <summary>
        /// Register commodity rate in credits
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="rate"></param>
        void AddRate(string commodity, double rate);
    }
}
