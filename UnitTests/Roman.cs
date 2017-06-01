using Merchant;
using Xunit;

namespace UnitTests
{
    public class Roman
    {
        [Fact]
        public void TestDoubles()
        {
            string[] inputs = { "II", "XX", "CC", "MM" };

            int[] outputs = { 2, 20, 200, 2000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestInvalidChar()
        {
            string[] inputs = { "IVZ", "IZX", "ZXL" };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestInvalidOrder()
        {
            //string[] inputs = { "I", "V", "X", "L", "C", "D", "M" };
            string[] inputs = { "IL", "IC", "ID", "IM",
                                "VX", "VL","VC","VD","VM",
                                "XD","XM",
                                "LC","LD","LM",
                                "DM"};

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestInvalidRepeatition()
        {
            string[] inputs = { "IIII", "VV", "XXXX", "LL", "CCCC", "DD", "MMMM" };


            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestSingles()
        {
            string[] inputs = { "I", "V", "X", "L", "C", "D", "M" };

            int[] outputs = { 1, 5, 10, 50, 100, 500, 1000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestSubtraction()
        {
            string[] inputs = { "IV", "IX", "XL", "XC", "CD", "CM" };

            int[] outputs = { 4, 9, 40, 90, 400, 900 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestTriples()
        {
            string[] inputs = { "III", "XXX", "CCC", "MMM" };

            int[] outputs = { 3, 30, 300, 3000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void OtherInvalidTests()
        {
            string[] inputs = { "IXI","MDM" };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void OtherValidTests()
        {
            string[] inputs = { "MCMLXXXIV", "MMXVII" };

            int[] outputs = { 1984, 2017 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                var output = RomanNumberConverter.NumberToInteger(input);
                Assert.Equal<int>(outputs[i], output);
            }
        }
    }
}