// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Merchant.Exceptions;
using System;

namespace Merchant.Models
{
    /// <summary>
    /// Provides Roman Digits representation and associated meta-data
    /// </summary>
    public abstract class RomanDigit : IEquatable<RomanDigit>
    {
        /// <summary>
        /// Contains the subtotal value
        /// </summary>
        public int SubTotal { get; private set; }

        /// <summary>
        /// Representation in char 'I', 'V',...
        /// </summary>
        public char Symbol { get; protected set; }

        /// <summary>
        /// Integer value: I:1, V:5, X:10
        /// </summary>
        public int Value { get; protected set; }

        /// <summary>
        /// Number that can subtract.
        /// </summary>
        protected char Less { get; set; } = ' ';

        /// <summary>
        /// Order used to control valid digits after subtraction
        /// </summary>
        protected int Order { get; set; }

        /// <summary>
        /// If can be used in repetition: II, XX,...
        /// </summary>
        protected bool Repeat { get; set; }

        /// <summary>
        /// Holds the previous digit
        /// </summary>
        private RomanDigit Previous { get; set; }

        /// <summary>
        /// Number of sequential repetitions
        /// </summary>
        private int Sequential { get; set; } = 1;

        /// <summary>
        /// If it is used for subtraction notation: IV, IX, XL,...
        /// </summary>
        private bool Subtract { get; set; }

        public static bool operator <(RomanDigit a, RomanDigit b)
        {
            if (b == null) { return false; }
            if (a == null) { return true; }
            return a.Value < b.Value;
        }

        public static bool operator >(RomanDigit a, RomanDigit b)
        {
            if (a == null) { return false; }
            if (b == null) { return true; }
            return a.Value > b.Value;
        }

        public override bool Equals(object obj)
        {
            var number = obj as RomanDigit;
            if (number == null) { return false; }
            return Equals(number);
        }

        public bool Equals(RomanDigit other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        /// <summary>
        /// Set the previous digit
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public virtual int SetPrevious(RomanDigit number)
        {
            Previous = number;

            if (Previous != null)
            {
                // If is subtraction
                if (Previous.Symbol == Less)
                {
                    if (Order == Previous.Order)
                    {
                        Order--;
                    }
                    else
                    {
                        Order -= 2;
                    }
                    Previous.Subtract = true;
                    // Update previous subtotal...
                    Previous.Calculate();
                }

                if (this.Equals(Previous))
                {
                    Sequential += Previous.Sequential;
                }
            }
            // Calculate subtotal so far...
            return Calculate();
        }

        /// <summary>
        /// Calculate the SubTotal
        /// </summary>
        /// <returns></returns>
        private int Calculate()
        {
            SubTotal = Previous == null ? 0 : Previous.SubTotal;

            Validate();

            if (Subtract)
            {
                SubTotal -= Value;
            }
            else
            {
                SubTotal += Value;
            }

            return SubTotal;
        }

        /// <summary>
        /// Validate roman number
        /// </summary>
        /// <returns></returns>
        private void Validate()
        {
            if (Sequential > 3 || (Sequential > 1 && !Repeat)) { throw new RomanDigitException("Invalid roman number: wrong digit repetition."); }
            if (Subtract && Sequential > 1) { throw new RomanDigitException("Invalid roman number: digit repetition after subtraction."); }
            if (Previous != null && Order > Previous.Order) { throw new RomanDigitException("Invalid roman number: invalid digit order."); }
        }
    }
}