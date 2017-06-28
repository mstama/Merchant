using Merchant.Exceptions;
using Merchant.Services;
using Xunit;

namespace UnitTests
{
    public partial class RomanNumberConverterTests
    {
        private const string _category = "RomanNumberConverter";

        private readonly RomanNumberConverter _target = new RomanNumberConverter();

        [Theory]
        [MemberData(nameof(GetOtherInvalid))]
        [MemberData(nameof(GetInvalidChar))]
        [MemberData(nameof(GetInvalidOrder))]
        [MemberData(nameof(GetInvalidRepetition))]
        [Trait("Category", _category)]
        public void InvalidTests(string input)
        {
            Assert.Throws<RomanDigitException>(() => _target.Convert(input));
        }

        [Theory]
        [MemberData(nameof(GetSingles))]
        [MemberData(nameof(GetDoubles))]
        [MemberData(nameof(GetTriples))]
        [MemberData(nameof(GetSubtractions))]
        [MemberData(nameof(GetOtherValid))]
        [Trait("Category", _category)]
        public void ValidTest(string input, int value)
        {
            // Act
            var output = _target.Convert(input);
            // Assert
            Assert.Equal<int>(value, output);
        }
    }
}