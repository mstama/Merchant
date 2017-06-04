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
        /// If can be used in repetition: II, XX,...
        /// </summary>
        public bool Repeat { get; protected set; }

        /// <summary>
        /// Number of sequential repetitions
        /// </summary>
        public int Sequential { get; set; } = 1;

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
        /// Representation in char 'I', 'V',...
        /// </summary>
        public char Symbol { get; protected set; }

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
        protected char Less { get; set; } = ' ';

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
            if (number == null || number.Symbol != Less) return false;
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
            CanSubtract = false;
        }
    }

    public class RomanNumberI : RomanNumber
    {
        public RomanNumberI()
        {
            Symbol = 'I';
            Repeat = true;
            Value = 1;
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
            CanSubtract = false;
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
            CanSubtract = false;
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
        }
    }
}