using System;
using System.Linq;

namespace Sorter
{
    /// <summary>
    /// Provide methods for converting data in different types.
    /// </summary>
    public static class MyConvert
    {
        /// <summary>
        /// Converts string data array to int array.
        /// </summary>
        /// <param name="strings">String data array.</param>
        /// <param name="dataType">Data type.</param>
        /// <returns>Returns converted data array.</returns>
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

        /// <summary>
        /// Converts int data array to string data.
        /// </summary>
        /// <param name="data">Int data array.</param>
        /// <param name="dataType">Data type.</param>
        /// <param name="separator">Output separator.</param>
        /// <returns>Returns converted string data.</returns>
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

        /// <summary>
        /// Converts string data array to int array.
        /// </summary>
        /// <param name="strings">String data array.</param>
        /// <param name="toBase">Indicates which number system to convert the data to.</param>
        /// <returns>Returns converted data array.</returns>
        private static int[] StringToInt(string[] strings, int toBase) =>
            strings.Select(word => Convert.ToInt32(word, toBase)).ToArray();

        /// <summary>
        /// Converts int data array to string data.
        /// </summary>
        /// <param name="data">Int data array.</param>
        /// <param name="separator">Output separator.</param>
        /// <param name="toBase">Indicates from which number system need to convert the items.</param>
        /// <returns>Returns converted and joined with output separator string array.</returns>
        private static string IntToString(int[] data, string separator, int toBase) =>
            string.Join(separator,
                data.Select(number => Convert.ToString(number, toBase)));
    }
}