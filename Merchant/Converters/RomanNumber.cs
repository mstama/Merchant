using System;
using System.Collections.Generic;

namespace Merchant.Converters
{
    /// <summary>
    /// Provides Roman Number representation and associated meta-data
    /// </summary>
    public abstract class RomanNumber
    {
        private bool _subtract = false;

        /// <summary>
        /// Representation in char 'I', 'V',...
        /// </summary>
        public char Number { get; protected set; }

        /// <summary>
        /// If can be used in repetition: II, XX,...
        /// </summary>
        public bool Repeat { get; protected set; }

        /// <summary>
        /// If it is used for subtraction notation: IV, IX, XL,...
        /// </summary>
        public bool Subtract
        {
            get
            {
                return _subtract;
            }
            set
            {
                if (CanSubtract) _subtract = value;
            }
        }

        /// <summary>
        /// Integer value: I:1, V:5, X:10
        /// </summary>
        public int Value { get; protected set; }

        /// <summary>
        /// If the number is allowed to subtract: I:true, V:false
        /// </summary>
        protected bool CanSubtract { get; set; } = true;

        /// <summary>
        /// Number that can subtract.
        /// </summary>
        protected char Previous { get; set; } = ' ';

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

        public virtual bool PreviousSubtract(RomanNumber number)
        {
            if (number == null || number.Number != Previous) return false;
            return true;
        }
    }

    public class RomanNumberC : RomanNumber
    {
        public RomanNumberC()
        {
            Number = 'C';
            Repeat = true;
            Value = 100;
            Previous = 'X';
        }
    }

    public class RomanNumberD : RomanNumber
    {
        public RomanNumberD()
        {
            Number = 'D';
            Repeat = false;
            Value = 500;
            Previous = 'C';
            CanSubtract = false;
        }
    }

    public class RomanNumberI : RomanNumber
    {
        public RomanNumberI()
        {
            Number = 'I';
            Repeat = true;
            Value = 1;
        }
    }

    public class RomanNumberL : RomanNumber
    {
        public RomanNumberL()
        {
            Number = 'L';
            Repeat = false;
            Value = 50;
            Previous = 'X';
            CanSubtract = false;
        }
    }

    public class RomanNumberM : RomanNumber
    {
        public RomanNumberM()
        {
            Number = 'M';
            Repeat = true;
            Value = 1000;
            Previous = 'C';
        }
    }

    public class RomanNumberV : RomanNumber
    {
        public RomanNumberV()
        {
            Number = 'V';
            Repeat = false;
            Value = 5;
            Previous = 'I';
            CanSubtract = false;
        }
    }

    public class RomanNumberX : RomanNumber
    {
        public RomanNumberX()
        {
            Number = 'X';
            Repeat = true;
            Value = 10;
            Previous = 'I';
        }
    }
}