using System;
using System.Linq;

namespace CSharpTrainingExample
{
    public class Base64Converter
    {
        private const char ZERO_CHAR = '0';
        private const int TWO = 2;
        private const int FOUR = 4;
        private const int SIX = 6;
        private const int EIGHT = 8;

        private const string UPPERCASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LOWERCASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";
        private const string DIGITS = "0123456789";
        private const string SPECIAL_SYMBOLS = "+/";
        private const string EQUAL = "=";

        private readonly string _allChars = string.Empty;

        public Base64Converter()
        {
            _allChars = $"{UPPERCASE_LETTERS}{LOWERCASE_LETTERS}{DIGITS}{SPECIAL_SYMBOLS}";
        }

        public string ConvertToWithLinq(string text)
        {
            var groups = text
                .ToCharArray();

            var binaries = groups
                .Select(x => Convert.ToString(x, TWO).PadLeft(EIGHT, ZERO_CHAR))
                .ToList();

            var allBinaries = string.Join(string.Empty, binaries);

            var binaryGroups = allBinaries
                .Select((x, i) => i)
                .Where(i => i % SIX == 0)
                .Select(i => String.Concat(allBinaries.Skip(i).Take(SIX)))
                .Select(i => i.PadRight(SIX, ZERO_CHAR))
                .Select(i => i.PadLeft(EIGHT, ZERO_CHAR))
                .ToList();

            var decimalGroups = binaryGroups
                .Select(x => Convert.ToInt32(x, 2))
                .ToList();

            var charGroups = decimalGroups
                .Select(x => _allChars[x])
                .ToList();

            string result = string.Join(string.Empty, charGroups);

            while (result.Length % FOUR != 0)
            {
                result += EQUAL;
            }

            return result;
        }
    }
}
