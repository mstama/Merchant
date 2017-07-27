// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace UnitTests
{
    public partial class RomanNumberConverterTests
    {
        public static IEnumerable<object[]> GetDoubles()
        {
            yield return new object[] { "II", 2 };
            yield return new object[] { "XX", 20 };
            yield return new object[] { "CC", 200 };
            yield return new object[] { "MM", 2000 };
        }

        public static IEnumerable<object[]> GetInvalidChar()
        {
            yield return new object[] { "IVZ" };
            yield return new object[] { "IZX" };
            yield return new object[] { "ZXL" };
        }

        public static IEnumerable<object[]> GetInvalidOrder()
        {
            yield return new object[] { "IL" };
            yield return new object[] { "IC" };
            yield return new object[] { "ID" };
            yield return new object[] { "IM" };
            yield return new object[] { "VX" };
            yield return new object[] { "VL" };
            yield return new object[] { "VC" };
            yield return new object[] { "VD" };
            yield return new object[] { "VM" };
            yield return new object[] { "XD" };
            yield return new object[] { "XM" };
            yield return new object[] { "LC" };
            yield return new object[] { "LD" };
            yield return new object[] { "LM" };
            yield return new object[] { "DM" };
        }

        public static IEnumerable<object[]> GetInvalidRepetition()
        {
            yield return new object[] { "IIII" };
            yield return new object[] { "VV" };
            yield return new object[] { "XXXX" };
            yield return new object[] { "LL" };
            yield return new object[] { "CCCC" };
            yield return new object[] { "DD" };
            yield return new object[] { "MMMM" };
        }

        public static IEnumerable<object[]> GetOtherInvalid()
        {
            yield return new object[] { "IXI" };
            yield return new object[] { "MDM" };
            yield return new object[] { "IXX" };
            yield return new object[] { "IIX" };
            yield return new object[] { "IXV" };
            yield return new object[] { "XCC" };
        }

        public static IEnumerable<object[]> GetOtherValid()
        {
            yield return new object[] { "MCMLXXXIV", 1984 };
            yield return new object[] { "MMXVII", 2017 };
            yield return new object[] { "MCMXCIV", 1994 };
            yield return new object[] { "XLII", 42 };
        }

        public static IEnumerable<object[]> GetSingles()
        {
            yield return new object[] { "I", 1 };
            yield return new object[] { "V", 5 };
            yield return new object[] { "X", 10 };
            yield return new object[] { "L", 50 };
            yield return new object[] { "C", 100 };
            yield return new object[] { "D", 500 };
            yield return new object[] { "M", 1000 };
        }

        public static IEnumerable<object[]> GetSubtractions()
        {
            yield return new object[] { "IV", 4 };
            yield return new object[] { "IX", 9 };
            yield return new object[] { "XL", 40 };
            yield return new object[] { "XC", 90 };
            yield return new object[] { "CD", 400 };
            yield return new object[] { "CM", 900 };
            yield return new object[] { "CDXLIV", 444 };
            yield return new object[] { "CMXCIX", 999 };
        }

        public static IEnumerable<object[]> GetTriples()
        {
            yield return new object[] { "III", 3 };
            yield return new object[] { "XXX", 30 };
            yield return new object[] { "CCC", 300 };
            yield return new object[] { "MMM", 3000 };
        }
    }
}