using Merchant;
using Merchant.Converters;
using Xunit;

namespace UnitTests
{
    public class RomanNumberConverterTests
    {
        [Fact]
        public void TestDoubles()
        {
            // Arrange
            string[] inputs = { "II", "XX", "CC", "MM" };

            int[] outputs = { 2, 20, 200, 2000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestInvalidChar()
        {
            // Arrange
            string[] inputs = { "IVZ", "IZX", "ZXL" };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestInvalidOrder()
        {
            // Arrange
            string[] inputs = { "IL", "IC", "ID", "IM",
                                "VX", "VL","VC","VD","VM",
                                "XD","XM",
                                "LC","LD","LM",
                                "DM"};

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestInvalidRepeatition()
        {
            // Arrange
            string[] inputs = { "IIII", "VV", "XXXX", "LL", "CCCC", "DD", "MMMM" };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void TestSingles()
        {
            // Arrange
            string[] inputs = { "I", "V", "X", "L", "C", "D", "M" };

            int[] outputs = { 1, 5, 10, 50, 100, 500, 1000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            string[] inputs = { "IV", "IX", "XL", "XC", "CD", "CM" };

            int[] outputs = { 4, 9, 40, 90, 400, 900 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void TestTriples()
        {
            // Arrange
            string[] inputs = { "III", "XXX", "CCC", "MMM" };

            int[] outputs = { 3, 30, 300, 3000 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(outputs[i], output);
            }
        }

        [Fact]
        public void OtherInvalidTests()
        {
            // Arrange
            string[] inputs = { "IXI", "MDM" };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(0, output);
            }
        }

        [Fact]
        public void OtherValidTests()
        {
            // Arrange
            string[] inputs = { "MCMLXXXIV", "MMXVII" };

            int[] outputs = { 1984, 2017 };

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];
                // Act
                var output = RomanNumberConverter.NumberToInteger(input);
                // Assert
                Assert.Equal<int>(outputs[i], output);
            }
        }
    }
}