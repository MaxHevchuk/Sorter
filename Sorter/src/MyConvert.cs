using System;
using System.Linq;

namespace Sorter
{
    /// <summary>
    /// Provide methods for converting data in different types.
    /// </summary>
    public static class MyConvert
    {
        public static int[] ToIntArray(string[] strings, Enum dataType)
        {
            return dataType switch
            {
                DataType.NumberBinary => StringToInt(strings, 2),
                DataType.NumberDecimal => StringToInt(strings, 10),
                DataType.NumberHexadecimal => StringToInt(strings, 16),
                _ => null
            };
        }

        public static string ToString(int[] data, Enum dataType, string separator)
        {
            return dataType switch
            {
                DataType.NumberBinary => IntToString(data, separator, 2),
                DataType.NumberDecimal => IntToString(data, separator, 10),
                DataType.NumberHexadecimal => IntToString(data, separator, 16),
                _ => null
            };
        }

        private static int[] StringToInt(string[] strings, int toBase) =>
            strings.Select(word => Convert.ToInt32(word, toBase)).ToArray();

        private static string IntToString(int[] data, string separator, int toBase) =>
            string.Join(separator,
                data.Select(number => Convert.ToString(number, toBase)));
    }
}