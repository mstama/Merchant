namespace Merchant.Models
{
    public class RomanDigitC : RomanDigit
    {
        public RomanDigitC()
        {
            Symbol = 'C';
            Repeat = true;
            Value = 100;
            Less = 'X';
            Order = 3;
        }
    }

    public class RomanDigitD : RomanDigit
    {
        public RomanDigitD()
        {
            Symbol = 'D';
            Repeat = false;
            Value = 500;
            Less = 'C';
            Order = 3;
        }
    }

    public class RomanDigitI : RomanDigit
    {
        public RomanDigitI()
        {
            Symbol = 'I';
            Repeat = true;
            Value = 1;
            Order = 1;
        }
    }

    public class RomanDigitL : RomanDigit
    {
        public RomanDigitL()
        {
            Symbol = 'L';
            Repeat = false;
            Value = 50;
            Less = 'X';
            Order = 2;
        }
    }

    public class RomanDigitM : RomanDigit
    {
        public RomanDigitM()
        {
            Symbol = 'M';
            Repeat = true;
            Value = 1000;
            Less = 'C';
            Order = 4;
        }
    }

    public class RomanDigitV : RomanDigit
    {
        public RomanDigitV()
        {
            Symbol = 'V';
            Repeat = false;
            Value = 5;
            Less = 'I';
            Order = 1;
        }
    }

    public class RomanDigitX : RomanDigit
    {
        public RomanDigitX()
        {
            Symbol = 'X';
            Repeat = true;
            Value = 10;
            Less = 'I';
            Order = 2;
        }
    }
}