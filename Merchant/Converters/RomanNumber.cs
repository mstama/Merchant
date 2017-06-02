using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Converters
{
    public abstract class RomanNumber
    {
        public char Number { get; protected set; }
        public bool Repeat { get; protected set; }
        public int Value { get; protected set; }
        protected int Previous { get; set; } = 0;
        protected bool CanSubtract { get; set; } = true;

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

        private bool _subtract = false;
        public virtual bool PreviousSubtract(RomanNumber number)
        {
            if (number == null || number.Value != Previous) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            var number = obj as RomanNumber;
            if (number == null) return false;
            return Value==number.Value;
        }

        public static bool operator >(RomanNumber a, RomanNumber b)
        {
            if (a == null) return false;
            if (b == null) return true;
            return a.Value > b.Value;
        }

        public static bool operator <(RomanNumber a, RomanNumber b)
        {
            if (b == null) return false;
            if (a == null) return true;
            return a.Value < b.Value;
        }

        public override int GetHashCode()
        {
            return Value;
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

    public class RomanNumberV : RomanNumber
    {
        public RomanNumberV()
        {
            Number = 'V';
            Repeat = false;
            Value = 5;
            Previous = 1;
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
            Previous = 1;
        }
    }

    public class RomanNumberL : RomanNumber
    {
        public RomanNumberL()
        {
            Number = 'L';
            Repeat = false;
            Value = 50;
            Previous = 10;
            CanSubtract = false;
        }
    }

    public class RomanNumberC : RomanNumber
    {
        public RomanNumberC()
        {
            Number = 'C';
            Repeat = true;
            Value = 100;
            Previous = 10;
        }
    }

    public class RomanNumberD : RomanNumber
    {
        public RomanNumberD()
        {
            Number = 'D';
            Repeat = false;
            Value = 500;
            Previous = 100;
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
            Previous = 100;
        }
    }

    public static class RomanNumberFactory
    {
        private static Dictionary<char, Func<RomanNumber>> _dict = new Dictionary<char, Func<RomanNumber>>();

        static RomanNumberFactory()
        {
            _dict['I'] = () => new RomanNumberI();
            _dict['V'] = () => new RomanNumberV();
            _dict['X'] = () => new RomanNumberX();
            _dict['L'] = () => new RomanNumberL();
            _dict['C'] = () => new RomanNumberC();
            _dict['D'] = () => new RomanNumberD();
            _dict['M'] = () => new RomanNumberM();
        }

        public static RomanNumber Create(char number)
        {
            if (_dict.ContainsKey(number))
            {
                return _dict[number]();
            }
            else
            {
                return null;
            }
        }
    }
}
