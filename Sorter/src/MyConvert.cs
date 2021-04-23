using System;
using System.Linq;

namespace Sorter
{
    /// <summary>
    /// Provide methods for converting data in different types.
    /// </summary>
    public static class MyConvert
    {
        public static int[] ToIntArray(string[] data, Enum dataType)
        {
            switch (dataType)
            {
                case DataType.IntTwo: return BinToInt(data);

                case DataType.IntTen: return DecimalToInt(data);

                case DataType.IntSixteen: return HexToInt(data);

                default:
                    return null;
            }
        }

        public static string ToString(int[] data, Enum dataType, string separator)
        {
            switch (dataType)
            {
                case DataType.IntTwo: return BinToString(data, separator);

                case DataType.IntTen: return DecimalToString(data, separator);

                case DataType.IntSixteen: return HexToString(data, separator);

                default:
                    return null;
            }
        }

        private static int[] BinToInt(string[] strings) => FromNumbers(strings, 2);

        private static int[] DecimalToInt(string[] strings) => FromNumbers(strings, 10);

        private static int[] HexToInt(string[] strings) => FromNumbers(strings, 16);

        private static int[] FromNumbers(string[] strings, int toBase) =>
            strings.Select(word => Convert.ToInt32(word, toBase)).ToArray();

        private static string BinToString(int[] data, string separator) => NumToString(data, separator, 2);

        private static string DecimalToString(int[] data, string separator) => NumToString(data, separator, 10);

        private static string HexToString(int[] data, string separator) => NumToString(data, separator, 16);

        private static string NumToString(int[] data, string separator, int toBase) => string.Join(separator,
            data.Select(number =>
                Convert.ToString(number, toBase)));
    }
}