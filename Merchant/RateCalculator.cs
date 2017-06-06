﻿using Merchant.Interfaces;
using System;
using System.Collections.Generic;

namespace Merchant
{
    /// <summary>
    /// Provides credit calculation for a registered commodity
    /// </summary>
    public class RateCalculator : IRateCalculator
    {
        private Dictionary<string, double> _dict = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Register commodity rate in credits
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="rate"></param>
        public void AddRate(string commodity, double rate)
        {
            if (string.IsNullOrWhiteSpace(commodity)) return;
            _dict.Add(commodity, rate);
        }

        /// <summary>
        /// Return commodity value in credits
        /// </summary>
        /// <param name="commodity"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double ToCredits(string commodity, int amount)
        {
            if (string.IsNullOrWhiteSpace(commodity)) return 0;
            double rate = _dict[commodity];
            return amount * rate;
        }
    }
}