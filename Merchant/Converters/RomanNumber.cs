using System;
using System.Collections.Generic;

namespace Merchant.Converters
{
    /// <summary>
    /// Provides Roman Number representation and associated meta-data
    /// </summary>
    public abstract class RomanNumber
    {
        /// <summary>
        /// Holds the previous number
        /// </summary>
        public RomanNumber Previous { get; set; }

        /// <summary>
        /// If can be used in repetition: II, XX,...
        /// </summary>
        public bool Repeat { get; protected set; }

        /// <summary>
        /// Number of sequential repetitions
        /// </summary>
        public int Sequential { get; set; } = 1;

        /// <summary>
        /// Contains the subtotal value
        /// </summary>
        public int SubTotal { get; set; }
        /// <summary>
        /// If it is used for subtraction notation: IV, IX, XL,...
        /// </summary>
        public bool Subtract { get; set; }

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
        /// Order used to control valid after subtraction
        /// </summary>
        protected int Order { get; set; }
        public static bool operator <(RomanNumber a, RomanNumber b)
        {
            if (b == null) return false;
            if (a == null) return true;
            return a.Value < b.Value;
        }

        public static bool operator >(RomanNumber a, RomanNumber b)
        {
            if (a == null) return false;
            if (b == null) return true;
            return a.Value > b.Value;
        }

        /// <summary>
        /// Add the previous number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public virtual int AddPrevious(RomanNumber number)
        {
            Previous = number;

            if (Previous != null)
            {
                // If is subtraction
                if (Previous.Symbol == Less)
                {
                    Order -= 2;
                    Previous.Subtract = true;
                    Previous.Calculate();
                }

                if (this.Equals(Previous))
                {
                    Sequential += Previous.Sequential;
                }
            }
            return Calculate();
        }

        public override bool Equals(object obj)
        {
            var number = obj as RomanNumber;
            if (number == null) return false;
            return Value == number.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
        /// <summary>
        /// Calculate the SubTotal
        /// </summary>
        /// <returns></returns>
        private int Calculate()
        {
            SubTotal = Previous == null ? 0 : Previous.SubTotal;

            if (!Validate())
            {
                SubTotal = 0;
                return SubTotal;
            }

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
        private bool Validate()
        {
            if (Sequential > 3 || (Sequential > 1 && !Repeat)) return false;
            if (Subtract && Sequential > 1) return false;
            if (Previous != null && Order > Previous.Order) return false;
            if (Previous != null && Previous.SubTotal == 0) return false;
            return true;
        }
    }

    public class RomanNumberC : RomanNumber
    {
        public RomanNumberC()
        {
            Symbol = 'C';
            Repeat = true;
            Value = 100;
            Less = 'X';
            Order = 3;
        }
    }

    public class RomanNumberD : RomanNumber
    {
        public RomanNumberD()
        {
            Symbol = 'D';
            Repeat = false;
            Value = 500;
            Less = 'C';
            Order = 3;
        }
    }

    public class RomanNumberI : RomanNumber
    {
        public RomanNumberI()
        {
            Symbol = 'I';
            Repeat = true;
            Value = 1;
            Order = 1;
        }
    }

    public class RomanNumberL : RomanNumber
    {
        public RomanNumberL()
        {
            Symbol = 'L';
            Repeat = false;
            Value = 50;
            Less = 'X';
            Order = 2;
        }
    }

    public class RomanNumberM : RomanNumber
    {
        public RomanNumberM()
        {
            Symbol = 'M';
            Repeat = true;
            Value = 1000;
            Less = 'C';
            Order = 4;
        }
    }

    public class RomanNumberV : RomanNumber
    {
        public RomanNumberV()
        {
            Symbol = 'V';
            Repeat = false;
            Value = 5;
            Less = 'I';
            Order = 1;
        }
    }

    public class RomanNumberX : RomanNumber
    {
        public RomanNumberX()
        {
            Symbol = 'X';
            Repeat = true;
            Value = 10;
            Less = 'I';
            Order = 2;
        }
    }
}