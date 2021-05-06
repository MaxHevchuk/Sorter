using System;
using System.Linq;

namespace Sorter
{
    /// <summary>
    /// Provide methods for checking if data matches the given data types. 
    /// </summary>
    public static class DataChecker
    {
        private const string AlphabetEnglish = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string AlphabetUkrainian = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгдеєжзиіїйклмнопрстуфхцчшщьюя";
        private const string NumbersBinary = "01";
        private const string NumbersDecimal = "-0123456789";
        private const string NumbersHexadecimal = "0123456789AaBbCcDdEeFf";

        
        /// <summary>
        /// Check if entered data is correct and corresponds to the entered data type. 
        /// </summary>
        /// <param name="data">Data represented by string type.</param>
        /// <param name="dataType">Data type.</param>
        /// <param name="separator">Entered separator.</param>
        /// <returns>Returns a boolean indicating the result of the checking.</returns>
        public static bool CheckForCorrect(string data, Enum dataType, string separator)
        {
            var dataArray = data.Split(new[] {separator}, StringSplitOptions.None);
            return dataType switch
            {
                DataType.StringEnglish => CheckIfElementsIsCorrect(dataArray, AlphabetEnglish),
                DataType.StringUkrainian => CheckIfElementsIsCorrect(dataArray, AlphabetUkrainian),
                DataType.NumberBinary => CheckIfElementsIsCorrect(dataArray, NumbersBinary),
                DataType.NumberDecimal => CheckIfElementsIsCorrect(dataArray, NumbersDecimal),
                DataType.NumberHexadecimal => CheckIfElementsIsCorrect(dataArray, NumbersHexadecimal),
                DataType.Length => true,
                _ => false
            };
        }

        /// <summary>
        /// Check that all items of the array are in string constant. 
        /// </summary>
        /// <param name="strings">Data array.</param>
        /// <param name="constant">String with all possible symbols for data type.</param>
        /// <returns>Returns a boolean indicating that all items are in possible symbols.</returns>
        private static bool CheckIfElementsIsCorrect(string[] strings, string constant) =>
            strings.All(element =>
                element.ToCharArray().All(constant.Contains));
    }
}